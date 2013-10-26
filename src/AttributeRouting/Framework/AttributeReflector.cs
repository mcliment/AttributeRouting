using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AttributeRouting.Helpers;

namespace AttributeRouting.Framework
{
    /// <summary>
    /// Creates <see cref="RouteSpecification"/> objects according to the 
    /// options set in implementations of <see cref="ConfigurationBase"/>.
    /// </summary>    
    public class AttributeReflector
    {
        private readonly ConfigurationBase _configuration;

        public AttributeReflector(ConfigurationBase configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            _configuration = configuration;
        }

        /// <summary>
        /// Yields all the information needed by <see cref="RouteBuilder"/> to build routes.
        /// </summary>
        public IEnumerable<RouteSpecification> BuildRouteSpecifications()
        {
            var controllerCount = 0; // needed to increment controller index
            var inheritActionsFromBaseController = _configuration.InheritActionsFromBaseController;

            var specs =
                // Each controller
                from controllerType in _configuration.OrderedControllerTypes
                let controllerIndex = controllerCount++
                let isAsyncController = controllerType.IsAsyncController()
                let convention = controllerType.GetCustomAttribute<UrlRouteConventionAttributeBase>(true)
                let urlRouteAreaAttribute = GetUrlRouteAreaAttribute(controllerType, convention)
                let subdomain = GetAreaSubdomain(urlRouteAreaAttribute)
                // Each action
                from actionMethod in controllerType.GetActionMethods(inheritActionsFromBaseController)
                let actionName = GetActionName(actionMethod, isAsyncController)
                let urlRoutePrefixAttributes = GetUrlRoutePrefixAttributes(controllerType, convention, actionMethod)
                // Each route attribute
                from urlRouteAttribute in GetUrlRouteAttributes(actionMethod, convention)
                // Each prefix so that the route is prefixed with each one available.
                // Using DefaultIfEmpty to simulate the notion of a left-join with the route attribute.
                // Taking only the first if ignoring route prefixes because prefixes will have no effect.
                from urlRoutePrefixAttribute in urlRoutePrefixAttributes.DefaultIfEmpty(null).Take(urlRouteAttribute.IgnoreRoutePrefix ? 1 : int.MaxValue)
                // Build the specification
                select new RouteSpecification
                {
                    ActionMethod = actionMethod,
                    ActionName = actionName,
                    ActionPrecedence = GetSortableOrder(urlRouteAttribute.ActionPrecedence),
                    AppendTrailingSlash = urlRouteAttribute.AppendTrailingSlashFlag,
                    AreaName = GetAreaName(urlRouteAreaAttribute, controllerType),
                    AreaUrl = GetAreaUrl(urlRouteAreaAttribute, subdomain, controllerType),
                    AreaUrlTranslationKey = urlRouteAreaAttribute.SafeGet(a => a.TranslationKey),
                    ControllerIndex = controllerIndex,
                    ControllerName = controllerType.GetControllerName(),
                    ControllerPrecedence = GetSortableOrder(urlRouteAttribute.ControllerPrecedence),
                    ControllerType = controllerType,
                    HttpMethods = urlRouteAttribute.HttpMethods,
                    IgnoreAreaUrl = urlRouteAttribute.IgnoreAreaUrl,
                    IgnoreRoutePrefix = urlRouteAttribute.IgnoreRoutePrefix,
                    IsAbsoluteUrl = urlRouteAttribute.IsAbsoluteUrl,
                    PrefixPrecedence = GetSortableOrder(urlRoutePrefixAttribute.SafeGet(a => a.Precedence, int.MaxValue)),
                    PreserveCaseForUrlParameters = urlRouteAttribute.PreserveCaseForUrlParametersFlag,
                    RouteName = urlRouteAttribute.RouteName,
                    RoutePrefixUrl = GetUrlRoutePrefixUrl(urlRoutePrefixAttribute, controllerType),
                    RoutePrefixUrlTranslationKey = urlRoutePrefixAttribute.SafeGet(a => a.TranslationKey),
                    RouteUrl = urlRouteAttribute.RouteUrl ?? actionName,
                    RouteUrlTranslationKey = urlRouteAttribute.TranslationKey,
                    SitePrecedence = GetSortableOrder(urlRouteAttribute.SitePrecedence),
                    Subdomain = subdomain,
                    UseLowercaseRoute = urlRouteAttribute.UseLowercaseRouteFlag,
                };

            // Return specs ordered by route precedence: 
            return specs.OrderBy(x => x.SitePrecedence)
                        .ThenBy(x => x.ControllerIndex)
                        .ThenBy(x => x.PrefixPrecedence)
                        .ThenBy(x => x.ControllerPrecedence)
                        .ThenBy(x => x.ActionPrecedence);
        }

        private static string GetActionName(MethodInfo actionMethod, bool isAsyncController)
        {
            var actionName = actionMethod.Name;
            
            if (isAsyncController && actionName.EndsWith("Async"))
            {
                actionName = actionName.Substring(0, actionName.Length - 5);
            }
            
            return actionName;
        }

        private static IEnumerable<IUrlRouteAttribute> GetUrlRouteAttributes(MethodInfo actionMethod, UrlRouteConventionAttributeBase convention)
        {
            var attributes = new List<IUrlRouteAttribute>();

            // Add convention-based attributes
            if (convention != null)
            {
                attributes.AddRange(convention.GetUrlRouteAttributes(actionMethod));
            }

            // Add explicitly-defined attributes
            attributes.AddRange(actionMethod.GetCustomAttributes<IUrlRouteAttribute>(false));

            return attributes;
        }

        private static UrlRouteAreaAttribute GetUrlRouteAreaAttribute(Type controllerType, UrlRouteConventionAttributeBase convention)
        {
            return controllerType.GetCustomAttribute<UrlRouteAreaAttribute>(true)
                   ?? convention.SafeGet(x => x.GetDefaultUrlRouteArea(controllerType));
        }

        private static string GetAreaName(UrlRouteAreaAttribute urlRouteAreaAttribute, Type controllerType)
        {
            if (urlRouteAreaAttribute == null)
            {
                return null;
            }

            // If given an area name, then use it.
            // Otherwise, use the last section of the namespace of the controller, as a convention.
            return urlRouteAreaAttribute.AreaName ?? controllerType.GetConventionalAreaName();
        }

        private static string GetAreaUrl(UrlRouteAreaAttribute urlRouteAreaAttribute, string subdomain, Type controllerType)
        {
            if (urlRouteAreaAttribute == null)
            {
                return null;
            }

            // If a subdomain is specified for the area either in the UrlRouteAreaAttribute 
            // or via configuration, then assume the area url is blank; eg: admin.badass.com.
            // However, our fearless coder can decide to explicitly specify an area url if desired;
            // eg: internal.badass.com/admin.
            if (subdomain.HasValue() && urlRouteAreaAttribute.AreaUrl.HasNoValue())
            {
                return null;
            }

            // If we're given an area url or an area name, then use it.
            // Otherwise, get the area name from the namespace of the controller, as a convention.
            var areaUrlOrName = urlRouteAreaAttribute.AreaUrl ?? urlRouteAreaAttribute.AreaName;
            return areaUrlOrName ?? controllerType.GetConventionalAreaName();
        }

        private string GetAreaSubdomain(UrlRouteAreaAttribute urlRouteAreaAttribute)
        {
            if (urlRouteAreaAttribute == null)
            {
                return null;
            }

            // Check for a subdomain override specified via configuration object.
            var subdomainOverride = (from o in _configuration.AreaSubdomainOverrides
                                     where o.Key == urlRouteAreaAttribute.AreaName
                                     select o.Value).FirstOrDefault();

            return subdomainOverride ?? urlRouteAreaAttribute.Subdomain;
        }

        private static IEnumerable<UrlRoutePrefixAttribute> GetUrlRoutePrefixAttributes(Type controllerType, UrlRouteConventionAttributeBase convention, MethodInfo actionMethod)
        {
            // If there are any explicit route prefixes defined, use them.
            var urlRoutePrefixAttributes = controllerType.GetCustomAttributes<UrlRoutePrefixAttribute>(true).ToList();

            // Otherwise apply conventional prefixes.
            if (!urlRoutePrefixAttributes.Any() && convention != null)
            {
                var oldConventionalRoutePrefix = convention.GetDefaultUrlRoutePrefix(actionMethod);
                if (oldConventionalRoutePrefix.HasValue())
                {
                    urlRoutePrefixAttributes.Add(new UrlRoutePrefixAttribute(oldConventionalRoutePrefix));
                }
                else
                {
                    urlRoutePrefixAttributes.AddRange(convention.GetDefaultUrlRoutePrefixes(controllerType));
                }
            }

            return urlRoutePrefixAttributes.OrderBy(a => GetSortableOrder(a.Precedence));
        }

        private static string GetUrlRoutePrefixUrl(UrlRoutePrefixAttribute urlRoutePrefixAttribute, Type controllerType)
        {
            if (urlRoutePrefixAttribute == null)
            {
                return null;
            }

            // If we're given route prefix url, use it.
            // Otherwise, use the controller name as a convention.
            return urlRoutePrefixAttribute.Url ?? controllerType.GetControllerName();
        }

        /// <summary>
        /// Gets the sortable order for the given value.
        /// </summary>
        /// <param name="value">An integer sort order, where positive N is Nth, and negative N is Nth from last.</param>
        /// <returns>The sortable order corresponding to the given value.</returns>
        private static long GetSortableOrder(int value)
        {
            return (value >= 0 ? long.MinValue : long.MaxValue) + value;
        }
    }
}
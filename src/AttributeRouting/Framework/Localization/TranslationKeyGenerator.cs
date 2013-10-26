using System;
using System.Linq.Expressions;
using AttributeRouting.Helpers;

namespace AttributeRouting.Framework.Localization
{
    /// <summary>
    /// Generates conventional keys for use with the translation provder.
    /// </summary>
    public class TranslationKeyGenerator
    {
        /// <summary>
        /// Generates the conventional key for the url of the specified area.
        /// </summary>
        /// <param name="areaName">The name of the area</param>
        public string AreaUrl(string areaName)
        {
            var areaKeyPart = areaName.HasValue() ? areaName + "_" : null;
            return areaKeyPart + "AreaUrl";
        }        

        /// <summary>
        /// Generates the conventional key for the url of the specified route prefix.
        /// </summary>
        /// <param name="areaName">The name of the area, if applicable</param>
        /// <param name="controllerName">The name of the controller</param>
        public string RoutePrefixUrl(string areaName, string controllerName)
        {
            var areaKeyPart = areaName.HasValue() ? areaName + "_" : null;
            return "{0}{1}_RoutePrefixUrl".FormatWith(areaKeyPart, controllerName);
        }        

        /// <summary>
        /// Generates the conventional key for the url of the specified route.
        /// </summary>
        /// <param name="areaName">The name of the area, if applicable</param>
        /// <param name="controllerName">The name of the controller</param>
        /// <param name="actionName">The name of the action method</param>
        public string RouteUrl(string areaName, string controllerName, string actionName)
        {
            var area = areaName.HasValue() ? areaName + "_" : null;
            return "{0}{1}_{2}_RouteUrl".FormatWith(area, controllerName, actionName);
        }

        /// <summary>
        /// Generates the conventional key for the url of the area on the specified controller.
        /// </summary>
        /// <typeparam name="TController">The type of the controller</typeparam>
        public string AreaUrl<TController>() {
            var controllerType = typeof(TController);

            var areaAttribute = controllerType.GetCustomAttribute<UrlRouteAreaAttribute>(true);
            if (areaAttribute == null)
                throw new AttributeRoutingException(
                    "There is no UrlRouteAreaAttribute associated with {0}.".FormatWith(controllerType.FullName));

            return AreaUrl(areaAttribute.AreaName);
        }

        /// <summary>
        /// Generates the conventional key for the url of the route prefix on the specified controller.
        /// </summary>
        /// <typeparam name="TController">The type of the controller</typeparam>
        public string RoutePrefixUrl<TController>() {
            var controllerType = typeof(TController);

            var urlRoutePrefixAttribute = controllerType.GetCustomAttribute<UrlRoutePrefixAttribute>(true);
            if (urlRoutePrefixAttribute == null)
                throw new AttributeRoutingException(
                    "There is no UrlRoutePrefixAttribute associated with {0}.".FormatWith(controllerType.FullName));

            var areaAttribute = controllerType.GetCustomAttribute<UrlRouteAreaAttribute>(true);

            return RoutePrefixUrl(areaAttribute.SafeGet(a => a.AreaName), controllerType.GetControllerName());
        }

        /// <summary>
        /// Generates the conventional key for the url of the route on the specified action method.
        /// </summary>
        /// <typeparam name="TController">The type of the controller</typeparam>
        /// <param name="action">Expression pointing to the the action method</param>
        public string RouteUrl<TController>(Expression<Func<TController, object>> action) {
            var controllerType = typeof(TController);
            var areaAttribute = controllerType.GetCustomAttribute<UrlRouteAreaAttribute>(true);
            var actionMemberInfo = ExpressionHelper.GetMethodInfo(action);

            return RouteUrl(areaAttribute.SafeGet(a => a.AreaName),
                            controllerType.GetControllerName(),
                            actionMemberInfo.Name);
        }
    }
}

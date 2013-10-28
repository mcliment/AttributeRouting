using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http.Routing;
using AttributeRouting.Constraints;
using AttributeRouting.Framework;
using AttributeRouting.Helpers;
using AttributeRouting.Web.Http.Constraints;

namespace AttributeRouting.Web.Http.WebHost.Framework
{
    public class RouteConstraintFactory : IRouteConstraintFactory
    {
        private readonly HttpWebConfiguration _configuration;

        public RouteConstraintFactory(HttpWebConfiguration configuration)
        {
            _configuration = configuration;
        }

        public RegexRouteConstraintBase CreateRegexRouteConstraint(string pattern, RegexOptions options = RegexOptions.None)
        {
            return new RegexRouteConstraint(pattern, options);
        }

        public IInboundHttpMethodConstraint CreateInboundHttpMethodConstraint(string[] httpMethods)
        {
            var httpMethodTypes = httpMethods.Select(x => new HttpMethod(x)).ToArray();
            return new InboundHttpMethodConstraint(httpMethodTypes);
        }

        public object CreateInlineRouteConstraint(string name, params object[] parameters)
        {
            var inlineRouteConstraints = _configuration.InlineRouteConstraints;
            if (inlineRouteConstraints.ContainsKey(name))
            {
                var type = inlineRouteConstraints[name];

                if (!typeof(IHttpRouteConstraint).IsAssignableFrom(type))
                    throw new AttributeRoutingException(
                        "The constraint \"{0}\" must implement System.Web.Routing.IRouteConstraint".FormatWith(type.FullName));

                return Activator.CreateInstance(type, parameters);
            }

            return null;
        }

        public ICompoundRouteConstraint CreateCompoundRouteConstraint(params object[] constraints)
        {
            return new CompoundRouteConstraint(constraints.Cast<IHttpRouteConstraint>().ToArray());
        }

        public IOptionalRouteConstraint CreateOptionalRouteConstraint(object constraint)
        {
            return new OptionalRouteConstraint((IHttpRouteConstraint)constraint);
        }

        public IQueryStringRouteConstraint CreateQueryStringRouteConstraint(object constraint)
        {
            return new QueryStringRouteConstraint((IHttpRouteConstraint)constraint);
        }
    }
}
using System.Net.Http;

namespace AttributeRouting.Web.Http
{
    /// <summary>
    /// Defines a route for an action constrained to requests providing an httpMethod value of PUT.
    /// </summary>
    public class PUTAttribute : HttpUrlRouteAttribute
    {
        /// <summary>
        /// Specify a route for a PUT request.
        /// </summary>
        /// <param name="routeUrl">The url that is associated with this action</param>
		public PUTAttribute(string routeUrl) : base(routeUrl, HttpMethod.Put, HttpMethod.Options) { }
    }
}
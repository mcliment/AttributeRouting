using System.Net.Http;

namespace AttributeRouting.Web.Http
{
    /// <summary>
    /// Defines a route for an action constrained to requests providing an httpMethod value of POST.
    /// </summary>
    public class POSTAttribute : HttpUrlRouteAttribute
    {
        /// <summary>
        /// Specify a route for a POST request.
        /// </summary>
        /// <param name="routeUrl">The url that is associated with this action</param>
		public POSTAttribute(string routeUrl) : base(routeUrl, HttpMethod.Post, HttpMethod.Options) { }
    }
}
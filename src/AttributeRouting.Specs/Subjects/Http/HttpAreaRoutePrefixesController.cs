using System.Web.Http;
using AttributeRouting.Web.Http;

namespace AttributeRouting.Specs.Subjects.Http
{
    [UrlRouteArea("ApiArea")]
    [UrlRoutePrefix("ApiPrefix")]
    public class HttpAreaRoutePrefixesController : ApiController
    {
        [GET("Get")]
        public string Get()
        {
            return "";
        }

        [GET("ApiPrefix/DuplicatePrefix")]
        public string DuplicatePrefix()
        {
            return "";
        }

        [GET("ApiAreaPrefixAbsolute", IsAbsoluteUrl = true)]
        public string Absolute()
        {
            return "";
        }

        [GET("ApiArea")]
        public string RelativeUrlIsAreaUrl()
        {
            return "";
        }
    }
}
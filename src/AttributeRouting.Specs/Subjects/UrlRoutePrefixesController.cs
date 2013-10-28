using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace AttributeRouting.Specs.Subjects
{
    [UrlRoutePrefix("Prefix")]
    public class UrlRoutePrefixesController : Controller
    {
        [GET("Index")]
        public ActionResult Index()
        {
            return Content("");
        }

        [GET("Prefix/DuplicatePrefix")]
        public ActionResult DuplicatePrefix()
        {
            return Content("");
        }

        [GET("PrefixAbsolute", IsAbsoluteUrl = true)]
        public ActionResult Absolute()
        {
            return Content("");
        }

        [GET("Prefixer")]
        public ActionResult RouteBeginsWithRoutePrefix()
        {
            return Content("");
        }

        [GET("NoPrefix", IgnoreRoutePrefix = true)]
        public string NoPrefix()
        {
            return "";
        }
    }
}
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace AttributeRouting.Specs.Subjects
{
    [UrlRoutePrefix("Prefix")]
    public class RoutePrefixesController : Controller
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

    [UrlRouteArea("Area")]
    [UrlRoutePrefix("Prefix")]
    public class AreaRoutePrefixesController : Controller
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

        [GET("AreaPrefixAbsolute", IsAbsoluteUrl = true)]
        public ActionResult Absolute()
        {
            return Content("");
        }

        [GET("Area")]
        public string RelativeUrlIsAreaUrl()
        {
            return "";
        }
    }

    [UrlRoutePrefix]
    public class DefaultRoutePrefixController : Controller
    {
        [GET("Index")]
        public ActionResult Index()
        {
            return Content("");
        }
    }

    [UrlRoutePrefix("FirstPrefix", Precedence = 1)]
    [UrlRoutePrefix("SecondPrefix")]
    public class MultipleRoutePrefixController : Controller
    {
        [GET("Index", ActionPrecedence = 1)]
        [GET("This/Is/Absolute", IsAbsoluteUrl = true)]
        public ActionResult Index()
        {
            return Content("");
        }
    }
}
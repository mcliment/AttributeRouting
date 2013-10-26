using System.Web.Mvc;
using AttributeRouting.Web;
using AttributeRouting.Web.Mvc;

namespace AttributeRouting.Specs.Subjects
{
    [UrlRouteArea("Cms", AreaUrl = "{culture}/Cms")]
    public class CulturePrefixController : Controller
    {
        [GET("Home")]
        public ActionResult Index()
        {
            return Content("content");
        }
    }

    [UrlRouteArea("Area")]
    [UrlRoutePrefix("Prefix")]
    public class TranslationController : Controller
    {
        [GET("Index")]
        public ActionResult Index()
        {
            return Content("content");
        }
    }

    [UrlRouteArea("CustomArea", TranslationKey = "CustomAreaKey")]
    [UrlRoutePrefix("CustomPrefix", TranslationKey = "CustomPrefixKey")]
    public class TranslationWithCustomKeysController : Controller
    {
        [GET("CustomIndex", TranslationKey = "CustomRouteKey")]
        public ActionResult CustomIndex()
        {
            return Content("content");
        }
    }

    [UrlRoutePrefix("Translate/Actions")]
    public class TranslateActionsController : Controller
    {
        [GET("Index")]
        public ActionResult Index(int id = 1)
        {
            return Content("content");
        }
    }
}

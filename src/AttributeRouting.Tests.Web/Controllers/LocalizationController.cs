using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace AttributeRouting.Tests.Web.Controllers
{
    [UrlRouteArea("Localization", AreaUrl = "{culture}/Localization")]
    [UrlRoutePrefix("Prefix")]
    public class LocalizationController : Controller
    {
        [GET("Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}

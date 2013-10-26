using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace AttributeRouting.Specs.Subjects.Areas.Sample
{
    [UrlRouteArea]
    public class DefaultRouteAreaController : Controller
    {
        [GET("Index")]
        public ActionResult Index()
        {
            return Content("");
        }
    }
}
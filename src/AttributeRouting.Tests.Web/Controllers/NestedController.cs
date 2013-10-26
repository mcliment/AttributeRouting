using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace AttributeRouting.Tests.Web.Controllers
{
    [UrlRoutePrefix("Resources/{resourceId}")]    
    public class NestedController : ControllerBase
    {
        [GET("Nested")]
        public ActionResult Index(int resourceId)
        {
            return View();
        }

        [GET("Nested/{id}")]
        public ActionResult Show(int resourceId, int id)
        {
            return View();
        }
    }
}
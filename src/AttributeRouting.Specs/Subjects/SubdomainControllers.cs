using System.Web.Mvc;
using AttributeRouting.Web;
using AttributeRouting.Web.Mvc;

namespace AttributeRouting.Specs.Subjects
{
    [UrlRouteArea("Users", Subdomain = "users")]
    public class SubdomainController : Controller
    {
        [GET("")]
        public ActionResult Index()
        {
            return Content("");
        }
    }

    [UrlRouteArea("NoSubdomain")]
    public class SubdomainControllerWithoutSubdomainInAttribute : Controller
    {
        [GET("")]
        public ActionResult Index()
        {
            return Content("");
        }
    }

    [UrlRouteArea("Admin", Subdomain = "private", AreaUrl = "admin")]
    public class SubdomainWithAreaUrlController : Controller
    {
        [GET("")]
        public ActionResult Index()
        {
            return Content("");
        }
    }
}

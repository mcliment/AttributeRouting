using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using AttributeRouting.Helpers;
using AttributeRouting.Web.Mvc;

namespace AttributeRouting.Specs.Subjects
{
    [RestfulRouteConvention]
    public class RestfulRouteConventionController : Controller
    {
        [GET("Legacy", IsAbsoluteUrl = true)]
        public ActionResult Index()
        {
            return Content("");
        }

        public ActionResult New()
        {
            return Content("");
        }

        public ActionResult Create()
        {
            return Content("");
        }

        public ActionResult Show(int id)
        {
            return Content("");
        }

        public ActionResult Edit(int id)
        {
            return Content("");
        }

        public ActionResult Update(int id)
        {
            return Content("");
        }

        public ActionResult Delete(int id)
        {
            return Content("");
        }

        public ActionResult Destroy(int id)
        {
            return Content("");
        }

        [GET("Custom")]
        public ActionResult Custom()
        {
            return Content("");
        }
    }

    [RestfulRouteConvention]
    [RoutePrefix("Prefix")]
    public class RestfulRouteConventionPrefixController : Controller
    {
        public ActionResult Index()
        {
            return Content("");
        }

        public ActionResult New()
        {
            return Content("");
        }

        public ActionResult Create()
        {
            return Content("");
        }

        public ActionResult Show(int id)
        {
            return Content("");
        }

        public ActionResult Edit(int id)
        {
            return Content("");
        }

        public ActionResult Update(int id)
        {
            return Content("");
        }

        public ActionResult Delete(int id)
        {
            return Content("");
        }

        public ActionResult Destroy(int id)
        {
            return Content("");
        }
    }

    [RestfulRouteConvention]
    public class RestfulRouteConventionWithExplicitOrderedRouteController : Controller
    {
        [GET("Primary", ActionPrecedence = 1)]
        public ActionResult Index()
        {
            return Content("");
        }
    }

    [RestfulRouteConvention]
    public class RestfulRouteConventionWithExplicitRouteController : Controller
    {
        [GET("Legacy", IsAbsoluteUrl = true)]
        public ActionResult Index()
        {
            return Content("");
        }
    }

    public class FakeConventionAttribute : RouteConventionAttributeBase
    {
        public override IEnumerable<IRouteAttribute> GetRouteAttributes(MethodInfo actionMethod)
        {
            yield return new GETAttribute(actionMethod.Name);
        }

        public override IEnumerable<RoutePrefixAttribute> GetDefaultRoutePrefixes(Type controllerType)
        {
            yield return new RoutePrefixAttribute("Yowza");
        }
    }

    [FakeConvention]
    public abstract class FakeConventionControllerBase : Controller
    {
    }

    public class DerivedFakeConventionController : FakeConventionControllerBase
    {
        public ActionResult Index()
        {
            return Content("");
        }
    }
}
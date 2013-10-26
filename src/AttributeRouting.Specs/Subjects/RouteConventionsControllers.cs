using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using AttributeRouting.Helpers;
using AttributeRouting.Web.Mvc;

namespace AttributeRouting.Specs.Subjects
{
    [RestfulUrlRouteConvention]
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

    [RestfulUrlRouteConvention]
    [UrlRoutePrefix("Prefix")]
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

    [RestfulUrlRouteConvention]
    public class RestfulRouteConventionWithExplicitOrderedRouteController : Controller
    {
        [GET("Primary", ActionPrecedence = 1)]
        public ActionResult Index()
        {
            return Content("");
        }
    }

    [RestfulUrlRouteConvention]
    public class RestfulRouteConventionWithExplicitRouteController : Controller
    {
        [GET("Legacy", IsAbsoluteUrl = true)]
        public ActionResult Index()
        {
            return Content("");
        }
    }

    public class FakeConventionAttribute : UrlRouteConventionAttributeBase
    {
        public override IEnumerable<IUrlRouteAttribute> GetUrlRouteAttributes(MethodInfo actionMethod)
        {
            yield return new GETAttribute(actionMethod.Name);
        }

        public override IEnumerable<UrlRoutePrefixAttribute> GetDefaultUrlRoutePrefixes(Type controllerType)
        {
            yield return new UrlRoutePrefixAttribute("Yowza");
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
﻿using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace AttributeRouting.Specs.Subjects
{
    [UrlRouteArea("Area")]
    public class AreasController : Controller
    {
        [GET("Index")]
        public ActionResult Index()
        {
            return Content("");
        }

        [GET("Area/DuplicatePrefix")]
        public ActionResult DuplicatePrefix()
        {
            return Content("");
        }

        [GET("AreaAbsolute", IsAbsoluteUrl = true)]
        public ActionResult Absolute()
        {
            return Content("");
        }

        [GET("Areas")]
        public ActionResult RouteBeginsWithAreaName()
        {
            return Content("");
        }

        [GET("NoAreaUrl", IgnoreAreaUrl = true)]
        public ActionResult NoAreaUrl()
        {
            return Content("");
        }
    }

    [UrlRouteArea("Area", AreaUrl = "ExplicitArea")]
    public class ExplicitAreaUrlController : Controller
    {
        [GET("Index")]
        public ActionResult Index()
        {
            return Content("");
        }

        [GET("ExplicitArea/DuplicatePrefix")]
        public ActionResult DuplicatePrefix()
        {
            return Content("");
        }
    }
}

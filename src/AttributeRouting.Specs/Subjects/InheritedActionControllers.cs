using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace AttributeRouting.Specs.Subjects
{
    [UrlRoutePrefix("InheritedActions")]
    public class SuperController : Controller
    {
        [GET("Index")]
        public virtual string Index()
        {
            return null;
        }
    }

    public class DerivedController : SuperController { }
    
    public class DerivedWithOverrideController : SuperController
    {
        [GET("IndexDerived")]
        public override string Index()
        {
            return base.Index();
        }
    }

    [UrlRouteArea("Super")]
    public class SuperWithAreaController : SuperController { }

    [UrlRouteArea("Derived")]
    public class DerivedWithAreaController : SuperWithAreaController { }

    [UrlRoutePrefix("InheritedActions/Super")]
    public class SuperWithPrefixController : SuperController { }

    [UrlRoutePrefix("InheritedActions/Derived")]
    public class DerivedWithPrefixController : SuperController { }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using AttributeRouting.Web.Http;

namespace AttributeRouting.Specs.Subjects.Http
{
    [UrlRoutePrefix("HttpBugFixes")]
    public class HttpBugFixesController : ApiController
    {
        [GET("devices(ua={id})")]
        public string ODataStyleUrl(int id)
        {
            return "howdy " + id;
        }
    }

    [UrlRoutePrefix("Issue102")]
    public class Issue102TestController : ApiController
    {
        [GET("")]
        public string Get()
        {
            return "";
        }

        [GET("{id}")]
        public string Get(int id)
        {
            return "";
        }
    }
}

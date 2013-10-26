using System;
using System.Web.Http;
using AttributeRouting.Web.Http;

namespace AttributeRouting.Specs.Subjects.Http
{
    [UrlRoutePrefix("Http-Area-Inline-Constraints/{id:int}")]
    public class HttpAreaInlineRouteConstraintsController : ApiController
    {
        [GET("Howdy")]
        public string Index()
        {
            return "howdy-do!";
        }
    }

    [UrlRoutePrefix("Http-Prefixed-Inline-Constraints/{id:int}")]
    public class HttpPrefixedInlineRouteConstraintsController : ApiController
    {
        [GET("Howdy")]
        public string Index()
        {
            return "howdy-do!";
        }
    }

    [UrlRoutePrefix("Http-Inline-Constraints")]
    public class HttpInlineRouteConstraintsController : ApiController
    {
        [GET("Querystring?{x:int}&{y}")]
        public string Querystring(int x, string y)
        {
            return "";
        }

        [GET("Alpha/{x:alpha}")]
        public string Alpha(string x)
        {
            return "";
        }

        [GET("Int/{x:int}")]
        public string Int(int x)
        {
            return "";
        }

        [GET("IntOptional/{x:int?}")]
        public string IntOptional(int? x)
        {
            return "";
        }

        [GET("Long/{x:long}")]
        public string Long(long x)
        {
            return "";
        }

        [GET("Float/{x:float}")]
        public string Float(float x)
        {
            return "";
        }

        [GET("Double/{x:double}")]
        public string Double(double x)
        {
            return "";
        }

        [GET("Decimal/{x:decimal}")]
        public string Decimal(decimal x)
        {
            return "";
        }

        [GET("Bool/{x:bool}")]
        public string Bool(bool x)
        {
            return "";
        }

        [GET("Guid/{x:guid}")]
        public string Guid(Guid x)
        {
            return "";
        }

        [GET("DateTime/{x:datetime}")]
        public string DateTime(DateTime x)
        {
            return "";
        }

        [GET("Length/{x:length(1)}")]
        public string Length(string x)
        {
            return "";
        }

        [GET("MinLength/{x:minlength(10)}")]
        public string MinLength(string x)
        {
            return "";
        }

        [GET("MaxLength/{x:maxlength(10)}")]
        public string MaxLength(string x)
        {
            return "";
        }

        [GET("LengthRange/{x:length(2, 10)}")]
        public string LengthRange(string x)
        {
            return "";
        }

        [GET("Min/{x:min(1)}")]
        public string Min(int x)
        {
            return "";
        }

        [GET("Max/{x:max(10)}")]
        public string Max(int x)
        {
            return "";
        }

        [GET("Range/{x:range(1, 10)}")]
        public string Range(int x)
        {
            return "";
        }

        [GET(@"Regex/{x:regex(^Howdy$)}")]
        public string Regex(int x)
        {
            return "";
        }

        [GET(@"RegexRange/{x:regex(\w{1,8})}")]
        public string RegexRange(string x)
        {
            return x;
        }
        
        [GET("Compound/{x:int:max(10)}")]
        public string Compound(int x)
        {
            return "";
        }

        [GET("EnumValue/{x:colorValue}")]
        public string EnumValue(Color x)
        {
            return "";
        }

        [GET("Enum/{x:color}")]
        public string Enum(Color x)
        {
            return "";
        }

        [GET("WithOptional/{x:color?}")]
        public string WithOptional(Color? x)
        {
            return "";
        }

        [GET("WithDefault/{x:color=red}")]
        public string WithDefault(Color x)
        {
            return "";
        }

        [GET("avatar/{width:int}x{height:int}/{image?}")]
        public string MultipleWithinUrlSegment(int width, int height, string image)
        {
            return "";
        }
    }
}
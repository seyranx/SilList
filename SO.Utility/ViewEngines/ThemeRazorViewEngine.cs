using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SO.Utility.ViewEngines
{
    public class ThemeRazorViewEngine : RazorViewEngine
    {

        public ThemeRazorViewEngine(string theme):base()
        {
          
            MasterLocationFormats = new[] {
            "~/Views/"+theme+"/{1}/{0}.cshtml",
            "~/Views/"+theme+"/{1}/{0}.cshtml",
            "~/Views/"+theme+"/Shared/{0}.cshtml",
            "~/Views/"+theme+"/Shared/{0}.cshtml",

             "~/Views/"+theme+"/Shared/Partials/{0}.cshtml",
             "~/Views/"+theme+"/Shared/Controls/{0}.cshtml",
             

             "~/Views/Shared/{0}.cshtml",
             "~/Views/Shared/Partials/{0}.cshtml",
             "~/Views/Shared/Controls/{0}.cshtml"
          };

            /*
            AreaViewLocationFormats = new[] {
            "~/Areas/{2}/Views/%1/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/%1/{1}/{0}.vbhtml",
            "~/Areas/{2}/Views/%1/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/%1/Shared/{0}.vbhtml"
        };

            AreaMasterLocationFormats = new[] {
            "~/Areas/{2}/Views/%1/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/%1/{1}/{0}.vbhtml",
            "~/Areas/{2}/Views/%1/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/%1/Shared/{0}.vbhtml"
        };

            AreaPartialViewLocationFormats = new[] {
            "~/Areas/{2}/Views/%1/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/%1/{1}/{0}.vbhtml",
            "~/Areas/{2}/Views/%1/Shared/{0}.cshtml",
            "~/Areas/{2}/Views/%1/Shared/{0}.vbhtml"
        };
             */


            
            ViewLocationFormats = MasterLocationFormats;
            PartialViewLocationFormats = MasterLocationFormats;



        }
    }
}

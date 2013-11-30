using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SO.SilList.Web.Controllers
{
    public class CityController : Controller
    {
        private CityTypeManager cityTypeManager = new CityTypeManager();
        
        public JsonResult Search(string id)
        {
            var result = cityTypeManager.search(id);
             
           var json = Json(result, JsonRequestBehavior.AllowGet);
           return json;
        }


    }
}

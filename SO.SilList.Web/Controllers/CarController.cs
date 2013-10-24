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
    public class CarController : Controller
    {
        private CarManager carManager = new CarManager();
        private CityTypeManager cityTypeManager = new CityTypeManager();
       
        //
        // GET: /Car/

        public ActionResult Index(CarVm input = null)
        {
            if (input == null) input = new CarVm();
          //  input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = carManager.search(input);
                return View(input);
            }
            return View();
        }

        public JsonResult Search(string keyword)
        {
            var result = cityTypeManager.search(keyword);
             
           var json = Json(result, JsonRequestBehavior.AllowGet);
           return json;
        }

    }
}

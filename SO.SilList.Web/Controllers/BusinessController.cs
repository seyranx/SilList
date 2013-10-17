using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Web.Controllers
{
    public class BusinessController : Controller
    {
        private BusinessManager businessManager = new BusinessManager();
        private BusinessCategoriesManager businessCategoryManager = new BusinessCategoriesManager();
        //
        // GET: /Rentals/

        public ActionResult Index(BusinessVm input = null, Paging paging = null)
        {
            if (input == null)
                input = new BusinessVm();
            
            if (this.ModelState.IsValid)
            {
                input = businessManager.search(input);
                return View(input);
            }

            return View();
        }

        public ActionResult Filter(BusinessVm input)
        {
            return PartialView("_Filter", input);
        }

        public ActionResult Details(Guid? id = null)
        {
            var idNew = new Guid("2c00a271-da52-49ed-ac5e-c0d8baa1dfb6");
            var result = businessManager.get(idNew);
            return View(result);
        }

        public ActionResult Categories(Guid? id = null)
        {
            var idNew = new Guid("6ebe653d-0a10-44bf-bff6-84e1dbe6e36d");
            var result = businessCategoryManager.get(idNew);
            return PartialView(result);
        }


    }
}

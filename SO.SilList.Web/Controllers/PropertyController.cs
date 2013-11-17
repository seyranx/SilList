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
    public class PropertyController : Controller
    {
        //
        // GET: /Rentals/

        private PropertyManager rentalManager = new PropertyManager();

        public ActionResult Index(PropertyVm input = null)
        {
            if (input == null) input = new PropertyVm();

            if (this.ModelState.IsValid)
            {
                input = rentalManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult Filter(PropertyVm input)
        {
            return PartialView("_Filter", input);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
    }
}

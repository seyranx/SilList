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
    public class RentalController : Controller
    {
        //
        // GET: /Rentals/

        private RentalManager rentalManager = new RentalManager();

        public ActionResult Index(RentalVm input = null)
        {
            if (input == null) input = new RentalVm();

            if (this.ModelState.IsValid)
            {
                input.result = rentalManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult Filter(RentalVm input)
        {
            return PartialView("_Filter", input);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
    }
}

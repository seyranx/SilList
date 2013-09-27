using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Web.Controllers
{
    public class ListingsController : Controller
    {
        private ListingManager listingManager = new ListingManager();
        
        // GET: /Rentals/
        /*
        public ActionResult Index()
        {
            return View();
        }
        */
        public ActionResult _ListingItem()
        {
            var results = listingManager.getAll(null);
            return PartialView(results);
        }
/*
        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }
*/
        public ActionResult Filter(ListingVm input)
        {
            return PartialView("_Filter", input);
            //return PartialView("_Filter");
        }

        public ActionResult ListingsBox()
        {
            return PartialView("_ListingsBox");
        }

        public ActionResult Index(ListingVm input = null)
        {
            if (input == null)
                input = new ListingVm();

            if (this.ModelState.IsValid)
            {
                input.result = listingManager.websearch(input);
                input.searchCount = listingManager.webcount(input);
                return View(input);
            }

            return View();
        }

        /*

        public ActionResult Index(ListingVm input = null)
        {
            if (input == null)
                input = new ListingVm();

            if (this.ModelState.IsValid)
            {
                input.result = listingManager.search(input);
                input.totalRowCount = listingManager.count(input);
                return View(input);
            }

            return View();
        }

        // [HttpPost]
        public ActionResult Details(Guid id)
        {
            var result = listingManager.get(id);
            return View(result);
        }

        public ActionResult Pagination(ListingVm input)
        {
            return PartialView("_Pagination", input);
        }

*/
    }
}

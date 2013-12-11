using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Manager.Managers;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Web.Controllers
{
    public class ListingsController : Controller
    {
        private ListingManager listingManager = new ListingManager();

        public ActionResult Index(ListingVm input = null, Paging paging = null)
        {
            if (input == null)
                input = new ListingVm();
            input.listing = new ListingVo();
            input.paging = paging;

            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = listingManager.websearch(input);
                return View(input);
            }

            return View();
        }

        public ActionResult _ListingItem()
        {
            var results = listingManager.getAll(null);
            return PartialView(results);
        }

        public ActionResult _Details(Guid id)
        {
            var result = listingManager.get(id);
            return PartialView(result);
        }

        public ActionResult Filter(ListingVm input)
        {
            return PartialView("_Filter", input);
        }

        public ActionResult ListingsBox()
        {
            return PartialView("_ListingsBox");
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
        public ActionResult Listings(int memberId)
        {
            var jobs = listingManager.getAll(memberId);
            return View(jobs);
        }
/*
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetNames(string term)
        {
            // A list of names to mimic results from a database
            List<string> nameList = new List<string>
            {
                "Jonathan", "Lisa", "Jordan", "Tyler", "Susan", "Brandon", "Clayton", "Elizabeth", "Jennifer"
            };

            var results = nameList.Where(n => n.StartsWith(term, StringComparison.OrdinalIgnoreCase));
            return new JsonResult()
            {
                Data = results.ToArray(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
*/
    }
}

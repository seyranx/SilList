using System;
using System.Collections.Generic;
using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Web.Controllers
{
    public class ListingCategoryTypeController : Controller
    {
        private ListingCategoryTypeManager listingCategoryTypeManager = new ListingCategoryTypeManager();

        public ActionResult getTopCategories()
        {
            var results = listingCategoryTypeManager.getAll(null);
            return PartialView("getTopCategories", results);
        }
/*
        public ActionResult Index(ListingCategoryTypeVm input = null, Paging paging = null)
        {
            if (input == null)
                input = new ListingCategoryTypeVm();
            input.listingCategoryType = new ListingCategoryTypeVo();
            input.paging = paging;

            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = listingCategoryTypeManager.search(input);
                return View(input);
            }

            return View();
        }

        public ActionResult List()
        {
            var results = listingCategoryTypeManager.getAll(null);
            return PartialView(results);
        }

        public ActionResult Filter(ListingCategoryTypeVm input)
        {
            return PartialView("_Filter", input);
        }

        public ActionResult Menu()
        {
           return PartialView("../Listing/_Menu");
        }



        [HttpPost]
        public ActionResult Create(ListingCategoryTypeVo input)
        {
            if (this.ModelState.IsValid)
            {

                var item = listingCategoryTypeManager.insert(input);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Create()
        {
            var vo = new ListingCategoryTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, ListingCategoryTypeVo input)
        {
            if (this.ModelState.IsValid)
            {
                var res = listingCategoryTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var result = listingCategoryTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = listingCategoryTypeManager.get(id);
            return View(result);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Delete(int id)
        {
            listingCategoryTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null)
        {
            ViewBag.listingCategoryTypes = listingCategoryTypeManager.getAll(null);
            var listingCategoryType = new ListingCategoryTypeVo();
            if (id != null)
            {
                listingCategoryType = listingCategoryTypeManager.get(id.Value);
            }
            return PartialView("_DropDownList", listingCategoryType);
        }
 */
    }
}


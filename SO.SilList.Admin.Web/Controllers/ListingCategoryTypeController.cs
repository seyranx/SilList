using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class ListingCategoryTypeController : Controller
    {
        private ListingCategoryTypeManager listingCategoryTypeManager = new ListingCategoryTypeManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var results = listingCategoryTypeManager.getAll(null);
            return PartialView(results);
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
            return View();
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

        public ActionResult Delete(int id)
        {
            listingCategoryTypeManager.delete(id);
            return RedirectToAction("Index");
        }
    }
}

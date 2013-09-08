using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Admin.Web.Controllers
{
    public class ListingController : Controller
    {
        private ListingManager listingManager = new ListingManager();

        public ActionResult Index(ListingVm input = null)
        {
            if (input == null) input = new ListingVm();

            if (this.ModelState.IsValid)
            {
                input = listingManager.search(input);
                return View(input);
            }

            return View();
        }

        public ActionResult Filter(ListingVm input)
        {
            return PartialView("_Filter", input);
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult List()
        {
            var results = listingManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(ListingVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = listingManager.insert(input);
                return RedirectToAction("Index");
            }

            return View();

        }

        public ActionResult Create()
        {
            var vo = new ListingVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, ListingVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = listingManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(Guid id)
        {
            var result = listingManager.get(id);
            return View(result);
        }

        public ActionResult Details(Guid id)
        {
            var result = listingManager.get(id);
            return View(result);
        }

        public ActionResult Pagination(ListingVm input = null)
        {
            return PartialView("_Pagination");
        }

        public ActionResult Delete(Guid id)
        {
            listingManager.delete(id);
            return RedirectToAction("Index");
        }
    }
}

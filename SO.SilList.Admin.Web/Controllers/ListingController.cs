using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class ListingController : Controller
    {
        private ListingManager listingManager = new ListingManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var results = listingManager.getAll(null);
            return PartialView(results);
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

        public ActionResult Details(Guid id)
        {
            var result = listingManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult Delete(Guid id)
        {
            listingManager.delete(id);
            return RedirectToAction("Index");
        }
    }
}

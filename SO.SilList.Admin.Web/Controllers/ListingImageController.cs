using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class ListingImagesController : Controller
    {
        private ListingImagesManager listingImagesManager = new ListingImagesManager();

        public ActionResult Index()
        {
            ViewBag.Title = "Listing Images";
            return View();
        }

        public ActionResult _List()
        {
            var results = listingImagesManager.getAll();
            return PartialView(results);
        }


        public ActionResult Menu()
        {
            return PartialView("../Listing/_Menu");
        }
        [HttpPost]
        public ActionResult Edit(Guid id, ListingImagesVo input)
        {
            if (this.ModelState.IsValid)
            {
                var res = listingImagesManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var result = listingImagesManager.get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(ListingImagesVo input)
        {
            if (this.ModelState.IsValid)
            {
                var item = listingImagesManager.insert(input);
                ListingImagesVo li = new ListingImagesVo();
                li.imageId = item.imageId;
                listingImagesManager.insert(li);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Create()
        {
            ListingImagesVo li = new ListingImagesVo();
            return View(li);
        }

        public ActionResult Details(Guid id)
        {
            var result = listingImagesManager.get(id);
            return View(result);
        }
        public ActionResult Delete(Guid id)
        {
            listingImagesManager.delete(id);
            return RedirectToAction("Index");
        }
    }
}

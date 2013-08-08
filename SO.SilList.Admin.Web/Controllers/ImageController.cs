using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class ImageController : Controller
    {
        private ImageManager imageManager = new ImageManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _List()
        {
            var results = imageManager.getAll(null);
            return PartialView(results);
        }
        
        public ActionResult BusinessImages()
        {
            var results = imageManager.getBusinessImages();
            return PartialView("Index", results);
        }

        public ActionResult CarImages()
        {
            var results = imageManager.getCarImages();
            return PartialView("_List", results);
        }

        public ActionResult ListingImages()
        {
            var results = imageManager.getListingImages();
            return PartialView(results);
        }

        // RentalImages misses imageId field
        //public ActionResult RentalImages()
        //{
        //    //var results = imageManager.getAll(null);
        //    var results = imageManager.getRentalImages();
        //    return PartialView(results);
        //}

        [HttpPost]
        public ActionResult Edit(Guid id, ImageVo input)
        {
            if (this.ModelState.IsValid)
            {
                var res = imageManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(Guid id)
        {
            var result = imageManager.get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(ImageVo input)
        {
            if (this.ModelState.IsValid)
            {
                var item = imageManager.insert(input);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            var result = imageManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult Delete(Guid id)
        {
            imageManager.delete(id);
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class RentalImageController : Controller
    {
        private RentalImagesManager rentalImagesManager = new RentalImagesManager();

        public ActionResult Index()
        {
            ViewBag.Title = "Rental Images";
            return View();
        }

        public ActionResult _List()
        {
            var results = rentalImagesManager.getAll();
            return PartialView(results);
        }

        public ActionResult Menu()
        {
            return PartialView("../Rental/_Menu");
        }
        [HttpPost]
        public ActionResult Edit(Guid id, RentalImageVo input)
        {
            if (this.ModelState.IsValid)
            {
                var res = rentalImagesManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var result = rentalImagesManager.get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(RentalImageVo input)
        {
            if (this.ModelState.IsValid)
            {
                var item = rentalImagesManager.insert(input);
                RentalImageVo ri = new RentalImageVo();
                ri.imageId = item.imageId;
                rentalImagesManager.insert(ri);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Create()
        {
            RentalImageVo vo = new RentalImageVo();
            return View(vo);
        }

        public ActionResult Details(Guid id)
        {
            var result = rentalImagesManager.get(id);
            return View(result);
        }
        public ActionResult Delete(Guid id)
        {
            rentalImagesManager.delete(id);
            return RedirectToAction("Index");
        }
    }
}

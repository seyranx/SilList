using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Admin.Web.Controllers
{
    public class RentalController : Controller
    {
        //
        // GET: /Rentals/

        private RentalManager rentalManager = new RentalManager();

        public ActionResult Index(RentalVm input = null,Paging paging = null)
        {
            if (input == null) input = new RentalVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = rentalManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult List()
        {
            var results = rentalManager.getAll(null);
            return PartialView("_List",results);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, RentalVm input)
        {
            if (this.ModelState.IsValid)
            {
                var result = rentalManager.update(input.rental, id);

                // Rental Images stuff
                ImageManager imageManager = new ImageManager();
                // removing unchecked images
                imageManager.RemoveImages(id, input.imagesToRemove, ImageCategory.rentalImage);
                // uploading new images from edit page
                imageManager.InsertUploadImages(id, Request.Files, Server, ImageCategory.rentalImage);

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var result = rentalManager.get(id);

            // Images
            ImageManager imageManager = new ImageManager();
            var rentalImages = imageManager.getRentalImages(id);
            RentalVm rentalVm = new RentalVm(result);
            rentalVm.imagesToRemove = imageManager.CreateOrAddToImageList(rentalImages, true);

            return View(rentalVm);
        }

        [HttpPost]
        public ActionResult Create(PropertyVo input)
        {
            if(this.ModelState.IsValid)
            {
                var rentalItem = rentalManager.insert(input);

                // Images
                ImageManager imageManager = new ImageManager();
                imageManager.InsertUploadImages(rentalItem.propertyId, Request.Files, Server, SO.SilList.Manager.Managers.ImageCategory.rentalImage);

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Create()
        {
            var vo = new PropertyVo();
            return View(vo);
        }

        public ActionResult Details(Guid id)
        {
            var result = rentalManager.get(id);

            // Images
            ImageManager imageManager = new ImageManager();
            ViewBag.Images = imageManager.getRentalImages(id);

            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("../Rental/_Menu");
        }

        public ActionResult Delete(Guid id)
        {
            rentalManager.delete(id);
            return RedirectToAction("index");
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(RentalVm input)
        {
            return PartialView("_Filter", input);
        }
    }
}

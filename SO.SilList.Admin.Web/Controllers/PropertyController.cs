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
    public class PropertyController : Controller
    {
        private PropertyManager propertyManager = new PropertyManager();

        public ActionResult Index(PropertyVm input = null,Paging paging = null)
        {
            if (input == null) input = new PropertyVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = propertyManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult List()
        {
            var results = propertyManager.getAll(null);
            return PartialView("_List",results);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, PropertyVm input)
        {
            if (this.ModelState.IsValid)
            {
                var result = propertyManager.update(input.property, id);

                // Property Images stuff
                ImageManager imageManager = new ImageManager();
                // removing unchecked images
                imageManager.RemoveImages(id, input.imagesToRemove, ImageCategory.propertyImage);
                // uploading new images from edit page
                imageManager.InsertUploadImages(id, Request.Files, Server, ImageCategory.propertyImage);

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var result = propertyManager.get(id);

            // Images
            ImageManager imageManager = new ImageManager();
            var propertyImages = imageManager.getPropertyImages(id);
            PropertyVm propertyVm = new PropertyVm(result);
            propertyVm.imagesToRemove = imageManager.CreateOrAddToImageList(propertyImages, true);

            return View(propertyVm);
        }

        [HttpPost]
        public ActionResult Create(PropertyVo input)
        {
            if(this.ModelState.IsValid)
            {
                var propertyItem = propertyManager.insert(input);

                // Images
                ImageManager imageManager = new ImageManager();
                imageManager.InsertUploadImages(propertyItem.propertyId, Request.Files, Server, SO.SilList.Manager.Managers.ImageCategory.propertyImage);

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
            var result = propertyManager.get(id);

            // Images
            ImageManager imageManager = new ImageManager();
            ViewBag.Images = imageManager.getPropertyImages(id);

            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("../Property/_Menu");
        }

        public ActionResult Delete(Guid id)
        {
            propertyManager.delete(id);
            return RedirectToAction("index");
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(PropertyVm input)
        {
            return PartialView("_Filter", input);
        }
    }
}

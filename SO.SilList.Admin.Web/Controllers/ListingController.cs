using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Admin.Web.Controllers
{
    public class ListingController : Controller
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

                // Images
                ImageManager imageManager = new ImageManager();
                imageManager.InsertUploadImages(item.listingId, Request.Files, Server, SO.SilList.Manager.Managers.ImageCategory.listingImage);

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
        public ActionResult Edit(Guid id, ListingVm input)
        {
            if (this.ModelState.IsValid)
            {
                var res = listingManager.update(input.listing, id);

                // Listing Images stuff
                ImageManager imageManager = new ImageManager();
                // removing unchecked images
                imageManager.RemoveImages(id, input.imagesToRemove, ImageCategory.listingImage);
                // uploading new images from edit page
                imageManager.InsertUploadImages(id, Request.Files, Server, ImageCategory.listingImage);

                return RedirectToAction("Index");
            }

            return View(input);
        }

        public ActionResult Edit(Guid id)
        {
            var result = listingManager.get(id);

            // Images
            ImageManager imageManager = new ImageManager();
            var listingImages = imageManager.getListingImages(id);
            ListingVm listingVm = new ListingVm(result);
            listingVm.imagesToRemove = imageManager.CreateOrAddToImageList(listingImages, true);

            return View(listingVm);
        }

        public ActionResult Details(Guid id)
        {
            var result = listingManager.get(id);
            // Images
            ImageManager imageManager = new ImageManager();
            ViewBag.Images = imageManager.getListingImages(id);

            return View(result);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Delete(Guid id)
        {
            listingManager.delete(id);
            return RedirectToAction("Index");
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Entry Status Type stuff
        public ActionResult EntryStatusIndex(ListingVm input = null, Paging paging = null)
        {
            if(input == null)
                input = new ListingVm();
            input.showPendingOnly = true;
            return Index(input, paging);
        }

        public ActionResult EntryStatusApprove(Guid id)
        {
            var result = listingManager.get(id);
            if (result != null)
                listingManager.Approve(id);
            return RedirectToAction("EntryStatusIndex");
        }
        public ActionResult EntryStatusDecline(Guid id)
        {
            var result = listingManager.get(id);
            if (result != null)
                listingManager.Decline(id);
            return RedirectToAction("EntryStatusIndex");
        }

    }
}

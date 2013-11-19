using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System.Web.Security;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Admin.Web.Controllers
{
    public class BusinessController : Controller
    {
        private BusinessManager businessManager = new BusinessManager();
        private EntryStatusTypeManager<BusinessVo> entryStatusTypeManager = new EntryStatusTypeManager<BusinessVo>();
          
        public ActionResult Index(BusinessVm input=null,Paging paging = null)
        {
            var user = Membership.GetUser();
            input.paging = paging;
            if (input == null)input = new BusinessVm();
            
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = businessManager.search(input);
                return View(input);
            }
           
            return View();

        }
        public ActionResult Filter(BusinessVm input)
        {
            return PartialView("_Filter", input);
        }
         
        [HttpPost]
        public ActionResult Edit(Guid id, BusinessVm input)
        {
            if (this.ModelState.IsValid)
            {
                var res = businessManager.update(input.business, id);

                // Business Images stuff
                ImageManager imageManager = new ImageManager();
                imageManager.RemoveImages(id, input.imagesToRemove, ImageCategory.businessImage);
                // uploading new images from edit page
                imageManager.InsertUploadImages(id, Request.Files, Server, ImageCategory.businessImage);

                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(Guid id)
        {
            var result = businessManager.get(id);
            ImageManager imageManager = new ImageManager();
            var businessImages = imageManager.getBusinessImages(id);
            BusinessVm businessVm = new BusinessVm(result);

            businessVm.imagesToRemove = imageManager.CreateOrAddToImageList(businessImages, true);

            return View(businessVm);
        }

        [HttpPost]
        public ActionResult Create(BusinessVo input)
        {

            if (this.ModelState.IsValid)
            {
                var item = businessManager.insert(input);

                ImageManager imageManager = new ImageManager();
                imageManager.InsertUploadImages(item.businessId, Request.Files, Server, SO.SilList.Manager.Managers.ImageCategory.businessImage);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Create()
        {
            var vo = new BusinessVo();
            return View(vo);
        }

        public ActionResult Details(Guid id)
        {
            //var idNew = new Guid("6ebe653d-0a10-44bf-bff6-84e1dbe6e36d");
            var result = businessManager.get(id);

            ImageManager imageManager = new ImageManager();
            ViewBag.Images = imageManager.getBusinessImages(id);

            return PartialView(result);
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
        

        public ActionResult Delete(Guid id)
        {
            businessManager.delete(id);
            return RedirectToAction("Index");
        }




        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Entry Status Type stuff
        public ActionResult EntryStatusIndex(EntryStatusTypeVm<BusinessVo> input = null, Paging paging = null)
        {
            if (input == null)
                input = new EntryStatusTypeVm<BusinessVo>();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = entryStatusTypeManager.search(input);
                return View(input);
            }
            return View();
        }
        public ActionResult _EntryStatusList()
        {
            var results = entryStatusTypeManager.getAll(null);
            return PartialView(results);
            //return PartialView("_EntryStatusList", results);
        }
        public ActionResult EntryStatusPagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
        public ActionResult EntryStatusFilter(EntryStatusTypeVm<SO.SilList.Manager.Models.ValueObjects.BusinessVo> input)
        {
            return PartialView("_EntryStatusFilter", input);
        }


        public ActionResult EntryStatusApprove(Guid id)
        {
            var result = entryStatusTypeManager.get(id);
            entryStatusTypeManager.Approve(id);
            return RedirectToAction("EntryStatusIndex");
        }
        public ActionResult EntryStatusDecline(Guid id)
        {
            var result = entryStatusTypeManager.get(id);
            entryStatusTypeManager.Decline(id);
            return RedirectToAction("EntryStatusIndex");
        }

    }
}

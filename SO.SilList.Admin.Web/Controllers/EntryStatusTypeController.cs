using SO.SilList.Manager.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Utility.Classes;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Admin.Web.Controllers
{
    public class EntryStatusTypeController : Controller
    {
        private EntryStatusTypeManager entryStatusTypeManager = new EntryStatusTypeManager();

        public ActionResult Index(EntryStatusTypeVm input = null, Paging paging = null)
        {
            if (input == null)
                input = new EntryStatusTypeVm();
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

        public ActionResult _List()
        {
            var results = entryStatusTypeManager.getAll(null);
            return PartialView(results);
            //return PartialView("_List", results);
        }

        //[DontTrackVisit]
        //public ActionResult DropDownList(Guid? id = null,string propertyName = null,string defaultValue = null)
        //{
        //    ViewBag.sites = entryStatusTypeManager.getAll(null);
        //    //var site = new JobVo();
        //    //if (id != null)
        //    //{
        //    //    job = entryStatusTypeManager.get(id.Value);
        //    //}
        //    if (propertyName == null)
        //        propertyName = "siteId";
        //    ViewBag.propertyName = propertyName;
        //    if (defaultValue == null)
        //        defaultValue = "Select One";
        //    ViewBag.defaultValue = defaultValue;

        //    return PartialView("_DropDownList", site);
        //}

        [DontTrackVisit]
        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult Details(Guid id)
        {
            var result = entryStatusTypeManager.get(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Guid id, JobVo input)
        {
            if (this.ModelState.IsValid)
            {
                var res = entryStatusTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(Guid id)
        {
            var result = entryStatusTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(Guid id)
        {
            entryStatusTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(EntryStatusTypeVm input)
        {
            return PartialView("_Filter", input);
        }


        public ActionResult Approve(Guid id)
        {
            var result = entryStatusTypeManager.get(id);
            entryStatusTypeManager.Approve(id);
            return RedirectToAction("Index");
        }
        public ActionResult Decline(Guid id)
        {
            var result = entryStatusTypeManager.get(id);
            entryStatusTypeManager.Decline(id);
            return RedirectToAction("Index");
        }
    }
}

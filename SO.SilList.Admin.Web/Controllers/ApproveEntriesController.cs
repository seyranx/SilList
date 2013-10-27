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
    public class ApproveEntriesController : Controller
    {

        private ApproveEntriesManager approveEntriesManager = new ApproveEntriesManager();

        public ActionResult Index(ApproveEntriesVm input = null, Paging paging = null)
        {
            if (input == null)
                input = new ApproveEntriesVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = ApproveEntriesManager.search(input);
                return View(input);
            }
            return View();
        }


        public ActionResult _List()
        {
            var results = ApproveEntriesManager.getAll(null);
            return PartialView(results);
            //return PartialView("_List", results);
        }

        [DontTrackVisit]
        public ActionResult DropDownList(int? id = null,string propertyName = null,string defaultValue = null)
        {
            ViewBag.sites = approveEntriesManager.getAll(null);
            var site = new SiteVo();
            if (id != null)
            {
                site = approveEntriesManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "siteId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;

            return PartialView("_DropDownList", site);
        }

        [DontTrackVisit]
        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        [HttpPost]
        public ActionResult Create(SiteVo input)
        {
            if (this.ModelState.IsValid)
            {
                var item = approveEntriesManager.insert(input);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Create()
        {
            var site = new SiteVo();
            return View(site);
        }


        public ActionResult Details(int id)
        {
            var result = approveEntriesManager.get(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(int id, SiteVo input)
        {
            if (this.ModelState.IsValid)
            {
                var res = approveEntriesManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = approveEntriesManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            approveEntriesManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(SiteVm input)
        {
            return PartialView("_Filter", input);
        }
    }    }
}

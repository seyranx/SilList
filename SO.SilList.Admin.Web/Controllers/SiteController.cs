using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Attributes;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Utility.Classes;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Admin.Web.Controllers
{
    public class SiteController : Controller
    {
        private SiteManager siteManager = new SiteManager();

        //
        // GET: /Site/

        public ActionResult Index(SiteVm input = null, Paging paging = null)
        {
            if (input == null) input = new SiteVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = siteManager.search(input);
                return View(input);
            }
            return View();
        }


        public ActionResult _List()
        {
            var results = siteManager.getAll(null);
            return PartialView(results);
        }

        [DontTrackVisit]
        public ActionResult DropDownList(int? id = null)
        {
            ViewBag.sites = siteManager.getAll(null);
            var site = new SiteVo();
            if (id != null)
            {
                site = siteManager.get(id.Value);
            }
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
                var item = siteManager.insert(input);
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
            var result = siteManager.get(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(int id, SiteVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = siteManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = siteManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            siteManager.delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Filter(SiteVm Input)
        {
            return PartialView("_Filter", Input);
        }
        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
    }
}

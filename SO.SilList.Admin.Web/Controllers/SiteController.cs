using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class SiteController : Controller
    {
        private SiteManager siteManager = new SiteManager();

        //
        // GET: /Site/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult _List()
        {
            var results = siteManager.getAll(null);
            return PartialView(results);
        }

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
//TODO: from here below. need to create views ...
        public ActionResult Delete(int id)
        {
            siteManager.delete(id);
            return RedirectToAction("Index");
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

 
    }
}

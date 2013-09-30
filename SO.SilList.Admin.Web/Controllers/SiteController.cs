using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Attributes;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class SiteController : Controller
    {
        private SiteManager siteManager = new SiteManager();
        // Url of the caller page (Index page of Business, Car, etc..)
        private static Uri urlReferrer { get; set; }
        private static string referrerName { get; set; }

        //
        // GET: /Site/
        public ActionResult Index(string backUrl = null)
        {
            // "Go Back to" button stuff
            string myController = Request.RequestContext.RouteData.Values["controller"].ToString();
            if (myController != "Site")
            {
                urlReferrer = Request.UrlReferrer;
                int indexEnd = Request.UrlReferrer.AbsolutePath.IndexOf('/', 1);
                referrerName = Request.UrlReferrer.AbsolutePath.Substring(1, indexEnd - 1);
                ViewBag.referrerName = referrerName;
            }
            return View();
        }


        public ActionResult _List()
        {
            // "Go Back to" button stuff
            string myController = Request.RequestContext.RouteData.Values["controller"].ToString();
            if (myController != "Site")
            {
                int indexEnd = Request.UrlReferrer.AbsolutePath.IndexOf('/', 1);
                referrerName = Request.UrlReferrer.AbsolutePath.Substring(1, indexEnd - 1);
                ViewBag.referrerName = referrerName;
            }
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
            // "Go Back to" button stuff
            ViewBag.urlReferrer = urlReferrer;
            ViewBag.referrerName = referrerName;

            var site = new SiteVo();
            return View(site);
        }


        public ActionResult Details(int id)
        {
            // "Go Back to" button stuff
            ViewBag.urlReferrer = urlReferrer;
            ViewBag.referrerName = referrerName;

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
            // "Go Back to" button stuff
            ViewBag.urlReferrer = urlReferrer;
            ViewBag.referrerName = referrerName;

            var result = siteManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            siteManager.delete(id);
            return RedirectToAction("Index");
        }
    }
}

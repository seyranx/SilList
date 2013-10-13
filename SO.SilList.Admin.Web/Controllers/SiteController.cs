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
        // Url of the caller page (Index page of Business, Car, etc..)
        private static Uri urlReferrer { get; set; }
        private static string referrerName { get; set; }

        //
        // GET: /Site/
        public ActionResult Index(SiteVm input = null, Paging paging = null, string backUrl = null, string backName = null)
        {
            // "Go Back to" button stuff
            if (backUrl != null && backName != null && backName != "Site")
            {
                var baseUrlString = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
                urlReferrer = new Uri(baseUrlString);
                urlReferrer = new Uri(urlReferrer, backUrl);
                referrerName = backName;

                ViewBag.backUrl = urlReferrer;
                ViewBag.backName = referrerName;
            }
            if (input == null)
                input = new SiteVm();
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
            // "Go Back to" button stuff
            if (urlReferrer != null)
            {
                ViewBag.backUrl = urlReferrer;
                ViewBag.backName = referrerName;
            }
            var results = siteManager.getAll(null);
            return PartialView(results);
            //return PartialView("_List", results);
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
            // "Go Back to" button stuff
            if (urlReferrer != null)
            {
                ViewBag.backUrl = urlReferrer;
                ViewBag.backName = referrerName;
            }

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
            /* Moved to the Menu 
            // "Go Back to" button stuff
            if (urlReferrer != null)
            {
                ViewBag.backUrl = urlReferrer;
                ViewBag.backName = referrerName;
            }
            */

            var site = new SiteVo();
            return View(site);
        }


        public ActionResult Details(int id)
        {
            /* Moved to the Menu 
            // "Go Back to" button stuff
            if (urlReferrer != null)
            {
                ViewBag.backUrl = urlReferrer;
                ViewBag.backName = referrerName;
            }
            */
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
            /* Moved to the Menu 
            // "Go Back to" button stuff
            if (urlReferrer != null)
            {
                ViewBag.backUrl = urlReferrer;
                ViewBag.backName = referrerName;
            }
            */

            var result = siteManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            siteManager.delete(id);
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
    }
}

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
    }
}

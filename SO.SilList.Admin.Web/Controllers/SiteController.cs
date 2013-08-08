using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Managers;

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


        public ActionResult List()
        {
            var results = siteManager.getAll(null);
            return PartialView(results);
        }

    }
}

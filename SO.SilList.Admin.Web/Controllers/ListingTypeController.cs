using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class ListingTypeController : Controller
    {
        private ListingTypeManager listingTypeManager = new ListingTypeManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var results = listingTypeManager.getAll(null);
            return PartialView(results);
        }


        public ActionResult Menu()
        {
            return PartialView("../Listing/_Menu");
        }

    }
}

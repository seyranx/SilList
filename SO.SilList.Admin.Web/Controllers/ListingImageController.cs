using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class ListingImagesController : Controller
    {
        private ListingImagesManager listingImagesManager = new ListingImagesManager();
        private ImageManager imagesManager = new ImageManager();
       
        public ActionResult Index()
        {
           ViewBag.Title = "Listing Images";
           return View();
        }

        public ActionResult List()
        {
           var results = imagesManager.getListingImages();
           return PartialView(results);
        }


        public ActionResult Menu()
        {
            return PartialView("../Listing/_Menu");
        }
    }
}

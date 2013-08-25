using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using System.IO;

namespace SO.SilList.Admin.Web.Controllers
{
    public class ImageController : Controller
    {
        private ImageManager imageManager = new ImageManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _List()
        {
            var results = imageManager.getAll(null);
            return PartialView(results);
        }

        public ActionResult DropDownList(Guid? id = null)
        {
           ViewBag.images = imageManager.getAll(null);
           var image = new ImageVo();
           if (id != null)
           {
              image = imageManager.get(id.Value);
           }
           return PartialView("_DropDownList", image);
        }


        public ActionResult BusinessImages()
        {
            ViewBag.Title = "Business Images";
            return View();
        }

        public ActionResult _ListBusinessImages()
        {
            var results = imageManager.getBusinessImages();
            //return PartialView("_ListBusinessImages", results);
            return PartialView(results);
        }

        public ActionResult CarImages()
        {
            ViewBag.Title = "Car Images";
            return View();
        }

        public ActionResult _ListCarImages()
        {
            var results = imageManager.getAllCarImages();
            return PartialView(results);
        }

        public ActionResult RentalImages()
        {
            ViewBag.Title = "Business Images";
            return View();
        }

        public ActionResult _ListRentalImages()
        {
            var results = imageManager.getRentalImages();
            //return PartialView("_ListBusinessImages", results);
            return PartialView(results);
        }

        public ActionResult ListingImages()
        {
            ViewBag.Title = "Listing Images";
            return View();
        }

        public ActionResult _ListListingImages()
        {
            var results = imageManager.getListingImages();
            return PartialView(results);
        }

        //// RentalImages misses imageId field
        //public ActionResult RentalImages()
        //{
        //    ViewBag.Title = "Rental Images";
        //    return View();
        //}
        //
        //public ActionResult _ListRentalImages()
        //{
        //    var results = imageManager.getRentalImages();
        //    return PartialView(results);
        //}

        [HttpPost]
        public ActionResult Edit(Guid id, ImageVo input)
        {
            if (this.ModelState.IsValid)
            {
                var res = imageManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var result = imageManager.get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(ImageVo input)
        {
            if (this.ModelState.IsValid)
            {
                var item = imageManager.insert(input);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            var result = imageManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult Delete(Guid id)
        {
            imageManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult ImageListWithUpload(Guid? id = null)
        {
            string csRelativeBasePath = GetBasePathFromConfig();
            string sBaseDir = "~/" + csRelativeBasePath;
            string sDir = Server.MapPath(sBaseDir);
            if (!Directory.Exists(sDir))
            {
                Directory.CreateDirectory(sDir); // todo: permissions for this folder ?
            }
            if (Request.Files.Count > 0)
            {
                // todo: need to make sure they are uploading image files 
                var UploadImage1 = Request.Files["UploadImage1"];
                var UploadImage2 = Request.Files["UploadImage2"];

                string UploadImageAbsFilePath1 = Path.Combine(sDir, Guid.NewGuid().ToString() + "." + Path.GetExtension(UploadImage1.FileName));
                string UploadImageAbsFilePath2 = Path.Combine(sDir, Guid.NewGuid().ToString() + "." + Path.GetExtension(UploadImage2.FileName));

                UploadImage1.SaveAs(UploadImageAbsFilePath1);
                UploadImage2.SaveAs(UploadImageAbsFilePath2);
            } 
            if (id != null)
            {
                ViewBag.carId = id;
                List<ImageVo> carImageList = imageManager.getCarImages(id.Value); 
                return PartialView("_ImageListWithUpload", carImageList);
            }
            return PartialView();
        }

        string GetBasePathFromConfig()
        {
            string sVal = System.Configuration.ConfigurationManager.AppSettings.Get("UserImagesFolder");
            if (String.IsNullOrEmpty(sVal))
                return "";
            else
                return sVal;
        }
    }
}

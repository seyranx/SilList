using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System.IO;
using System.Diagnostics;

namespace SO.SilList.Admin.Web.Controllers
{
    public class CarController : Controller
    {
        private CarManager carManager = new CarManager();
        //
        // GET: /Car/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult List()
        {
            var results = carManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(CarVo input)
        {
            if (this.ModelState.IsValid)
            {
                var item = carManager.insert(input);


                /////////////////////////////////////////////////////////////////
                // carImage stuff. todo: need to move to Image controller or whatever ... to reuse from other locations
                var id = item.carId;
                ImageManager imageManager = new ImageManager();
                string csRelativeBasePath = imageManager.GetBasePathFromConfig();
                string sBaseDir = Path.Combine("~/" + csRelativeBasePath);
                string sDir = Server.MapPath(sBaseDir);

                // todo: need to make sure we have write access to this folder.
                if (!Directory.Exists(sDir))
                {
                    Directory.CreateDirectory(sDir);
                }

                if (Request.Files.Count > 0)
                {
                    // todo: need to make sure they are uploading image files 
                    var UploadImage1 = Request.Files["UploadImage1"];
                    var UploadImage2 = Request.Files["UploadImage2"];

                    if (UploadImage1 != null && UploadImage1.FileName != null)
                    {
                        string fileName1 = Path.GetFileName(UploadImage1.FileName);
                        string fileExtension1 = Path.GetExtension(UploadImage1.FileName);
                        if (!string.IsNullOrEmpty(fileName1) && imageManager.IsImageFile(fileExtension1))
                        {
                            string imageNameOnServer = Guid.NewGuid().ToString() + fileExtension1;
                            string uploadImageAbsFilePath1 = Path.Combine(sDir, imageNameOnServer);
                            UploadImage1.SaveAs(uploadImageAbsFilePath1);
                            string imageUrl = Path.Combine("~/", imageManager.GetBasePathFromConfig(), imageNameOnServer);
                            imageManager.InsertImageAndCarImage(id, fileName1, imageUrl, uploadImageAbsFilePath1);
                        }
                    }
                    if (UploadImage2 != null && UploadImage2.FileName != null)
                    {
                        string fileName2 = Path.GetFileName(UploadImage2.FileName);
                        string fileExtension2 = Path.GetExtension(UploadImage2.FileName);
                        if (!string.IsNullOrEmpty(fileName2) && imageManager.IsImageFile(fileExtension2))
                        {
                            string imageNameOnServer = Guid.NewGuid().ToString() + fileExtension2;
                            string uploadImageAbsFilePath2 = Path.Combine(sDir, imageNameOnServer);
                            string imageUrl = Path.Combine("~/", imageManager.GetBasePathFromConfig(), imageNameOnServer);
                            imageManager.InsertImageAndCarImage(id, fileName2, imageUrl, uploadImageAbsFilePath2);
                            UploadImage2.SaveAs(uploadImageAbsFilePath2);
                        }
                    }
                }
               
                /////////////////////////////////////////////////////////////////

                return RedirectToAction("Index");
            }

            return View();

        }

        public ActionResult Create()
        {
            var vo = new CarVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, CarVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = carManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(Guid id)
        {
            var result = carManager.get(id);
            return View(result);
        }

        public ActionResult Details(Guid id)
        {
            var result = carManager.get(id);
            return View(result);
        }

        public ActionResult Delete(Guid id)
        {
            carManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(Guid? id = null)
        {
            ViewBag.cars = carManager.getAll(null);
            var car = new CarVo();
            if (id != null)
            {
                car = carManager.get(id.Value);
            }
            return PartialView("_DropDownList", car);
        }
    }
}

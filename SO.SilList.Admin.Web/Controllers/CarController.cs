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

        public ActionResult Index(CarVm input = null)
        {
            if (input == null)
                input = new CarVm();
            input.car = new CarVo();
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.pageNumber = 1;
                input = carManager.search(input);
                return View(input);
            }
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
            Debug.Assert(Request.HttpMethod == "POST");
            if (this.ModelState.IsValid)
            {

                var item = carManager.insert(input);

                //if (Request.Files.Count > 0)
                //{
                //    // todo: need to make sure they are uploading image files 
                //    var UploadImage1 = Request.Files["UploadImage1"];
                //    var UploadImage2 = Request.Files["UploadImage2"];
                //}
                //HttpRequestBase x = Request;
                //HttpPostedFileBase y = x.Files["UploadImage1"];
                //HttpFileCollectionBase ya = x.Files;

                ImageManager imageManager = new ImageManager();
                imageManager.InsertImageForCar(item.carId, Request.Files, Server);

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
        public ActionResult Edit(Guid id, CarVm input)
        {
            if (this.ModelState.IsValid && input.car != null)
            {
                var res = carManager.update(input.car, id);

                // Care Images stuff
                ImageManager imageManager = new ImageManager();
                // removing unchecked images
                if (input.imagesToRemove != null)
                {
                    for (int ind = 0; ind < input.imagesToRemove.Count(); ind++)
                    {
                        bool imgChecked = input.imagesToRemove[ind].imageIsChecked;
                        if (!imgChecked)
                        {
                            string strGuid = input.imagesToRemove[ind].imageIdStr;
                            Guid imgGuid = Guid.Empty;
                            if (Guid.TryParse(strGuid, out imgGuid))
                            {
                                imageManager.RemoveImageForCar(id, imgGuid);
                            }
                        }
                    }
                }
                // uploading new images from edit page
                imageManager.InsertImageForCar(id, Request.Files, Server);

                return RedirectToAction("Index");
            }

            return View(input);

        }
        public ActionResult Edit(Guid id)
        {
            var result = carManager.get(id);

            ImageManager imageManager = new ImageManager();
            if (result.modelTypeId != null)
                result.makeTypeId = (int)result.modelType.makeTypeId;

            var carImages = imageManager.getCarImages(id);
            CarVm carVm = new CarVm(result);
            foreach (ImageVo image in carImages)
            {
                carVm.AddCarImageInfo(image, true);
            }
            return View(carVm);
        }

        public ActionResult Details(Guid id)
        {
            var result = carManager.get(id);

            ImageManager imageManager = new ImageManager();
            ViewBag.carImages = imageManager.getCarImages(id);

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

        public ActionResult Pagination(CarVm input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(CarVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

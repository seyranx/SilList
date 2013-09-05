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
            Debug.Assert(Request.HttpMethod == "POST");
            if (this.ModelState.IsValid)
            {
                var item = carManager.insert(input);

                if (Request.Files.Count > 0)
                {
                    // todo: need to make sure they are uploading image files 
                    var UploadImage1 = Request.Files["UploadImage1"];
                    var UploadImage2 = Request.Files["UploadImage2"];
                }
                HttpRequestBase x = Request;
                HttpPostedFileBase y = x.Files["UploadImage1"];
                HttpFileCollectionBase ya = x.Files;

                ImageManager imageManager = new ImageManager();
                var Files = Request.Files;
                imageManager.InsertImageForCar(item.carId, x.Files);

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

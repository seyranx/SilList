using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class CarImageController : Controller
    {
       private CarImageManager carImageManager = new CarImageManager();
 
        public ActionResult Index()
        {
           ViewBag.Title = "Car Images";
           return View();
        }

        public ActionResult _List()
        {
           var results = carImageManager.getAll();
           return PartialView(results);
        }

        public ActionResult Menu()
        {
            return PartialView("../Car/_Menu");
        }
        [HttpPost]
        public ActionResult Edit(Guid id, CarImagesVo input)
        {
           if (this.ModelState.IsValid)
           {
              var res = carImageManager.update(input, id);
              return RedirectToAction("Index");
           }

           return View();
        }

        public ActionResult Edit(Guid id)
        {
           var result = carImageManager.get(id);
           return View(result);
        }

        [HttpPost]
        public ActionResult Create(CarImagesVo input)
        {
           if (this.ModelState.IsValid)
           {
              var item = carImageManager.insert(input);
              CarImagesVo li = new CarImagesVo();
              li.imageId = item.imageId;
              carImageManager.insert(li);
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
           var result = carImageManager.get(id);
           return View(result);
        }
        public ActionResult Delete(Guid id)
        {
           carImageManager.delete(id);
           return RedirectToAction("Index");
        }
    }
}

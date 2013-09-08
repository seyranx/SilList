using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Admin.Web.Controllers
{
    public class CarController : Controller
    {
        private CarManager carManager = new CarManager();
        //
        // GET: /Car/

        public ActionResult Index(CarVm input = null)
        {
            if (input == null) input = new CarVm();
            if (this.ModelState.IsValid)
            {
                input.result = carManager.search(input);
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

            if (this.ModelState.IsValid)
            {

                var item = carManager.insert(input);
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
            if (result.modelTypeId != null)
                result.makeTypeId = (int)result.modelType.makeTypeId;
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

        public ActionResult Pagination(CarVm input)
        {
            return PartialView("_Pagination",input);
        }

        public ActionResult Filter(CarVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Admin.Web.Controllers
{
    public class CarDoorTypeController : Controller
    {
        private CarDoorTypeManager carDoorTypeManager = new CarDoorTypeManager();
        //
        // GET: /CarDoorType/

        public ActionResult Index(CarDoorTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new CarDoorTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = carDoorTypeManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("../Car/_Menu");
        }

        public ActionResult List()
        {
            var results = carDoorTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(CarDoorTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = carDoorTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new CarDoorTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, CarDoorTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = carDoorTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = carDoorTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = carDoorTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            carDoorTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null)
        {
            ViewBag.doors = carDoorTypeManager.getAll(null);
            var door = new CarDoorTypeVo();
            if (id != null)
            {
                door = carDoorTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "carDoorTypeId";
            ViewBag.propertyName = propertyName;
            return PartialView("_DropDownList", door);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(CarDoorTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

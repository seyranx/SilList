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
    public class CarFuelTypeController : Controller
    {
        private CarFuelTypeManager carFuelTypeManager = new CarFuelTypeManager();
        //
        // GET: /CarFuelType/

        public ActionResult Index(CarFuelTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new CarFuelTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = carFuelTypeManager.search(input);
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
            var results = carFuelTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(CarFuelTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = carFuelTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new CarFuelTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, CarFuelTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = carFuelTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = carFuelTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = carFuelTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            carFuelTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null)
        {
            ViewBag.Fuels = carFuelTypeManager.getAll(null);
            var fuel = new CarFuelTypeVo();
            if (id != null)
            {
                fuel = carFuelTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "carFuelTypeId";
            ViewBag.propertyName = propertyName;
            return PartialView("_DropDownList", fuel);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(CarFuelTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

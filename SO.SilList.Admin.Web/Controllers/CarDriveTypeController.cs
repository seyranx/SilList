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
    public class CarDriveTypeController : Controller
    {
        private CarDriveTypeManager carDriveTypeManager = new CarDriveTypeManager();
        //
        // GET: /CarDriveType/

        public ActionResult Index(CarDriveTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new CarDriveTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = carDriveTypeManager.search(input);
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
            var results = carDriveTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(CarDriveTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = carDriveTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new CarDriveTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, CarDriveTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = carDriveTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = carDriveTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = carDriveTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            carDriveTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null)
        {
            ViewBag.drives = carDriveTypeManager.getAll(null);
            var drive = new CarDriveTypeVo();
            if (id != null)
            {
                drive = carDriveTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "carDriveTypeId";
            ViewBag.propertyName = propertyName;
            return PartialView("_DropDownList", drive);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(CarDriveTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

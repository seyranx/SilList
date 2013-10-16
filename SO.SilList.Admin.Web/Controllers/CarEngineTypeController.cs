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
    public class CarEngineTypeController : Controller
    {
        private CarEngineTypeManager carEngineTypeManager = new CarEngineTypeManager();
        //
        // GET: /CarEngineType/

        public ActionResult Index(CarEngineTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new CarEngineTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = carEngineTypeManager.search(input);
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
            var results = carEngineTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(CarEngineTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = carEngineTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new CarEngineTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, CarEngineTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = carEngineTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = carEngineTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = carEngineTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            carEngineTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null)
        {
            ViewBag.engines = carEngineTypeManager.getAll(null);
            var engine = new CarEngineTypeVo();
            if (id != null)
            {
                engine = carEngineTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "carEngineTypeId";
            ViewBag.propertyName = propertyName;
            return PartialView("_DropDownList", engine);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(CarEngineTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Admin.Web.Controllers
{
    public class CarColorTypeController : Controller
    {
        private CarColorTypeManager carColorTypeManager = new CarColorTypeManager();

        //
        // GET: /CarColorType/

        public ActionResult Index(CarColorTypeVm input = null, Paging paging= null)
        {
            if (input == null) input = new CarColorTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = carColorTypeManager.search(input);
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
            var results = carColorTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(CarColorTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = carColorTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new CarColorTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, CarColorTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = carColorTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = carColorTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = carColorTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            carColorTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.colors = carColorTypeManager.getAll(null);
            var color = new CarColorTypeVo();
            if (id != null)
            {
                color  = carColorTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "carColorTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_DropDownList", color);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination",input);
        }

        public ActionResult Filter(CarColorTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

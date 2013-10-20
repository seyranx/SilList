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
    public class CarBodyTypeController : Controller
    {
        private CarBodyTypeManager carBodyTypeManager = new CarBodyTypeManager();
        //
        // GET: /CarBodyType/

        public ActionResult Index(CarBodyTypeVm input = null, Paging paging= null)
        {
            if (input == null) input = new CarBodyTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = carBodyTypeManager.search(input);
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
            var results = carBodyTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(CarBodyTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = carBodyTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new CarBodyTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, CarBodyTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = carBodyTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = carBodyTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = carBodyTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            carBodyTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.bodies = carBodyTypeManager.getAll(null);
            var body = new CarBodyTypeVo();
            if (id != null)
            {
                body = carBodyTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "carBodyTypeId"; 
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_DropDownList", body);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination",input);
        }

        public ActionResult Filter(CarBodyTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

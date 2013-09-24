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
    public class CarBodyTypeController : Controller
    {
        private CarBodyTypeManager carBodyTypeManager = new CarBodyTypeManager();
        //
        // GET: /CarBodyType/

        public ActionResult Index(CarBodyTypeVm input = null)
        {
            if (input == null) input = new CarBodyTypeVm();
            if (this.ModelState.IsValid)
            {
                input.result = carBodyTypeManager.search(input);
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

        public ActionResult DropDownList(int? id = null)
        {
            ViewBag.bodies = carBodyTypeManager.getAll(null);
            var body = new CarBodyTypeVo();
            if (id != null)
            {
                body = carBodyTypeManager.get(id.Value);
            }
            return PartialView("_DropDownList", body);
        }

        public ActionResult Pagination()
        {
            return PartialView("_Pagination");
        }

        public ActionResult Filter(CarBodyTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

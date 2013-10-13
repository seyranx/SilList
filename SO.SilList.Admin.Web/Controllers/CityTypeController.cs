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
    public class CityTypeController : Controller
    {
        private CityTypeManager CityTypeManager = new CityTypeManager();
        //
        // GET: /CityType/

        public ActionResult Index(CityTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new CityTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = CityTypeManager.search(input);
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
            var results = CityTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(CityTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = CityTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new CityTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, CityTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = CityTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = CityTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = CityTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            CityTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null)
        {
            ViewBag.cities = CityTypeManager.getAll(null);
            var city = new CityTypeVo();
            if (id != null)
            {
                city = CityTypeManager.get(id.Value);
            }
            return PartialView("_DropDownList", city);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(CityTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

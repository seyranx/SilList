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
    public class CountryTypeController : Controller
    {
        private CountryTypeManager CountryTypeManager = new CountryTypeManager();
        //
        // GET: /CountryType/

        public ActionResult Index(CountryTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new CountryTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = CountryTypeManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("../Admin/_Menu");
        }

        public ActionResult List()
        {
            var results = CountryTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(CountryTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = CountryTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new CountryTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, CountryTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = CountryTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = CountryTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = CountryTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            CountryTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.Countries = CountryTypeManager.getAll(null);
            var country = new CountryTypeVo();
            if (id != null)
            {
                country = CountryTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "countryTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_DropDownList", country);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(CountryTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

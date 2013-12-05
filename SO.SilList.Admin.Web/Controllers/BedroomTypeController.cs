using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;


namespace SO.SilList.Admin.Web.Controllers
{
    public class BedroomTypeController : Controller
    {
        private BedroomTypeManager bedroomTypeManager = new BedroomTypeManager();

        //
        // GET: /BedroomType/

        public ActionResult Index(BedroomTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new BedroomTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = bedroomTypeManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("../Property/_Menu");
        }

        public ActionResult List()
        {
            var results = bedroomTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(BedroomTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = bedroomTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new BedroomTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, BedroomTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = bedroomTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = bedroomTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = bedroomTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            bedroomTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.engines = bedroomTypeManager.getAll(null);
            var engine = new BedroomTypeVo();
            if (id != null)
            {
                engine = bedroomTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "bedroomTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_DropDownList", engine);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(BedroomTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}


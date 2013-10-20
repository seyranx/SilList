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
    public class ModelTypeController : Controller
    {
        private ModelTypeManager modelTypeManager = new ModelTypeManager();
        //
        // GET: /ModelType/

        public ActionResult Index(ModelTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new ModelTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = modelTypeManager.search(input);
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
            var results = modelTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(ModelTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = modelTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new ModelTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, ModelTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = modelTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = modelTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = modelTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            modelTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, int? _makeTypeId = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.models = modelTypeManager.getAll(null,_makeTypeId);
            var model = new ModelTypeVo();
            if (id != null)
            {
                model = modelTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "modelTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_DropDownList", model);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination",input);
        }

        public ActionResult Filter(ModelTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

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
    public class StateTypeController : Controller
    {
        private StateTypeManager StateTypeManager = new StateTypeManager();
        //
        // GET: /StateType/

        public ActionResult Index(StateTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new StateTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = StateTypeManager.search(input);
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
            var results = StateTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(StateTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = StateTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new StateTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, StateTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = StateTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = StateTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = StateTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            StateTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null)
        {
            ViewBag.states = StateTypeManager.getAll(null);
            var state = new StateTypeVo();
            if (id != null)
            {
                state = StateTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "stateTypeId";
            ViewBag.propertyName = propertyName;
            return PartialView("_DropDownList", state);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(StateTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

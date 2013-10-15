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
    public class MakeTypeController : Controller
    {
        private MakeTypeManager makeTypeManager = new MakeTypeManager();
        //
        // GET: /MakeType/

        public ActionResult Index(MakeTypeVm input = null,Paging paging = null)
        {
            if (input == null) input = new MakeTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = makeTypeManager.search(input);
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
            var results = makeTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(MakeTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = makeTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new MakeTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, MakeTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = makeTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = makeTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = makeTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            makeTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null)
        {
            ViewBag.makes = makeTypeManager.getAll(null);
            var make = new MakeTypeVo();
            if (id != null)
            {
                make = makeTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "modelTypeId";
            ViewBag.propertyName = propertyName;
            return PartialView("_DropDownList", make);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination",input);
        }

        public ActionResult Filter(MakeTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class ModelTypeController : Controller
    {
        private ModelTypeManager modelTypeManager = new ModelTypeManager();
        //
        // GET: /ModelType/

        public ActionResult Index()
        {
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

        public ActionResult DropDownList(int? id = null)
        {
            ViewBag.models = modelTypeManager.getAll(null);
            var model = new ModelTypeVo();
            if (id != null)
            {
                model = modelTypeManager.get(id.Value);
            }
            return PartialView("_DropDownList", model);
        }
    }
}

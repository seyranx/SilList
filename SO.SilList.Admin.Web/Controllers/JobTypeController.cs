using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class JobTypeController : Controller
    {
        private JobTypeManager jobTypeManager = new JobTypeManager();
        //
        // GET: /JobType/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return PartialView("../Job/Menu");
        }
        public ActionResult List()
        {
            var results = jobTypeManager.getAll(null);
            return PartialView(results);
        }
        [HttpPost]
        public ActionResult Create(JobTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = jobTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new JobTypeVo();
            return View(vo);
        }
        [HttpPost]
        public ActionResult Edit(int id, JobTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = jobTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = jobTypeManager.get(id);
            return View(result);
        }
        public ActionResult Details(int id)
        {
            var result = jobTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            jobTypeManager.delete(id);
            return RedirectToAction("Index");
        }
       /* public ActionResult DropDownList(int? id = null)
        {
            ViewBag.models = jobTypeManager.getAll(null);
            var model = new ModelTypeVo();
            if (id != null)
            {
                model = jobTypeManager.get(id.Value);
            }
            return PartialView("_DropDownList", model);
       // }*/
    }
}

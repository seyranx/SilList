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
    public class JobTypeController : Controller
    {
        private JobTypeManager jobTypeManager = new JobTypeManager();
        //
        // GET: /JobType/

        public ActionResult Index(JobTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new JobTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = jobTypeManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("../Job/_Menu");
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
        public ActionResult Filter(JobTypeVm Input)
        {
            return PartialView("_Filter", Input);
        }
        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
        public ActionResult DropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.bodies = jobTypeManager.getAll(null);
            var body = new JobTypeVo();
            if (id != null)
            {
                body = jobTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "jobTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_DropDownList", body);
        }
    }
}

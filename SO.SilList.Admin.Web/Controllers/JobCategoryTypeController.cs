using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Utility.Classes;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Admin.Web.Controllers
{
    public class JobCategoryTypeController : Controller
    {
        private JobCategoryTypeManager jobCategoryTypeManager = new JobCategoryTypeManager();
        //
        // GET: /jobCategoryType/

        public ActionResult Index(JobCategoryTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new JobCategoryTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = jobCategoryTypeManager.search(input);
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
            var results = jobCategoryTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(JobCategoryTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = jobCategoryTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, JobCategoryTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = jobCategoryTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = jobCategoryTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = jobCategoryTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            jobCategoryTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Filter(JobCategoryTypeVm Input)
        {
            return PartialView("_Filter", Input);
        }
        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult DropDownList(List<int> id = null, string propertyName = null)
        {
            ViewBag.bodies = jobCategoryTypeManager.getAll(null);
            var body = new JobCategoryTypeVo();
            if (id != null)
            {
                ViewBag.jobCategoryTypeIds = id;
            }
            
            if (propertyName == null)
                propertyName = "jobCategoryTypeId";
            ViewBag.propertyName = propertyName;

            return PartialView("_DropDownList");
        }
    }
}

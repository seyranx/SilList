using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SO.SilList.Web.Controllers
{
    
    public class JobsController : Controller
    {
        private JobManager jobManager = new JobManager();
        private JobTypeManager jobTypeManager = new JobTypeManager();
        private JobCategoryTypeManager jobCategoryTypeManager = new JobCategoryTypeManager();

        public ActionResult Index(JobVm input = null, Paging paging = null)
        {
            if (input == null) input = new JobVm();
            input.isActive = true;
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = jobManager.search(input);
                return View(input);
            }
            return View();
        }
        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(JobVm input)
        {
            return PartialView("_Filter", input);
        }
        public ActionResult Detail(Guid id)
        {
            var result = jobManager.get(id);
            return View(result);
        }
        public ActionResult Create()
        {
            var vo = new JobVo();
            return View(vo);
        }
        [HttpPost]
        public ActionResult Create(JobVo input)
        {

            if (this.ModelState.IsValid)
            {
                var item = jobManager.insert(input);

                return RedirectToAction("Index");
            }
            return View();

        }

        public ActionResult CollapseList(int? id = null, string propertyName = null, Type modelType = null)
        {
            ViewBag.selectedId = id;
            ViewBag.propertyName = propertyName;
      
            if (modelType == typeof(JobTypeVo))
            {
                ViewBag.list = jobTypeManager.getAll(true); 
               // var idList = list.Select(c => c.makeTypeId).ToList();
                ViewBag.propertyId = "jobTypeId";
                ViewBag.titleName = "Job Type";
            }
            else if(modelType == typeof(JobCategoryTypeVo))
            {
                ViewBag.list = jobCategoryTypeManager.getAll(true);
                ViewBag.propertyId = "jobCategoryTypeId";
                ViewBag.titleName = "Job Categories";
            }
            return PartialView("_CollapseList");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null, Type modelType = null, string defaultValue = null)
        {
            //var item = Activator.CreateInstance(modelType);
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;

            ViewBag.selectedItem = id;
            if (modelType == typeof(JobTypeVo))
            {
                ViewBag.items = jobTypeManager.getAll(true);
                ViewBag.idName = "jobTypeId";
            }


            return PartialView("_DropDownList");
        }

    }
}

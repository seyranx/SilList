
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
        private CityTypeManager cityTypeManager = new CityTypeManager();
        private JobCategoriesManager jobCategoriesManager = new JobCategoriesManager();
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

                if (input.jobCategoryType != null)
                {
                    foreach (int categoryId in input.jobCategoryType)
                    {
                        var categoryVo = new JobCategoriesVo();
                        categoryVo.jobId = input.jobId;
                        categoryVo.jobCategoryTypeId = categoryId;
                        categoryVo.isActive = true;

                        jobCategoriesManager.insert(categoryVo);
                       
                    }
                }


                return RedirectToAction("Index");
            }

            return View(input);

        }

        public ActionResult Edit(Guid id)
        {
            JobVo vo = jobManager.get(id);
            if (vo.jobCategories.Count > 0)
                vo.jobCategoryType = new List<int>();
            foreach (var item in vo.jobCategories)
            {
                vo.jobCategoryType.Add((int)item.jobCategoryTypeId);
            }
            return View(vo);
        }
        [HttpPost]
        public ActionResult Edit(Guid id, JobVo input)
        {
            JobCategoriesManager jobCategoriesManager = new JobCategoriesManager();
            bool foundTheMatch = false;
            JobVo item = jobManager.get(input.jobId);
            if (this.ModelState.IsValid)
            {
                foreach (JobCategoriesVo categoryVo in item.jobCategories)
                {
                    foundTheMatch = false;
                    foreach (int categoryId in input.jobCategoryType)
                    {
                        if (categoryVo.jobCategoryTypeId == categoryId)
                        {
                            input.jobCategoryType.Remove(categoryId);
                            foundTheMatch = true;
                            break;
                        }
                    }
                    if (!foundTheMatch)
                        jobCategoriesManager.delete(categoryVo.jobCategoriesId);
                }
                JobCategoriesVo categoryVo2 = new JobCategoriesVo();
                foreach (int categoryId in input.jobCategoryType)
                {

                    categoryVo2.jobId = input.jobId;
                    categoryVo2.jobCategoryTypeId = categoryId;
                    categoryVo2.isActive = true;

                    jobCategoriesManager.insert(categoryVo2);
                    categoryVo2 = new JobCategoriesVo();
                }
                var res = jobManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View(input);
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
            else if (modelType == typeof(CityTypeVo))
            {
                ViewBag.items = cityTypeManager.getAll(true);
                ViewBag.idName = "cityTypeId";
            }
            else if (modelType == typeof(JobCategoryTypeVo))
            {
                ViewBag.items = jobCategoryTypeManager.getAll(true);
                ViewBag.idName = "jobCategoryTypeId";
                return PartialView("_CategoryTypeDropDownList");
            }
            
            return PartialView("_DropDownList");
        }

        public void SendEmial(string email,string name,string message)
        {
            EmailManager emailManager = new EmailManager();
            emailManager.sendMail(email, "vazricv@silverobject.com", name, message);
        }

    }
}

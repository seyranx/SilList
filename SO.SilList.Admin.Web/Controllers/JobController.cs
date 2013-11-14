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
    public class JobController : Controller
    {

        private JobManager jobManager = new JobManager();
        //
        // GET: /Rentals/

        public ActionResult Index(JobVm input = null, Paging paging = null)
        {
            if (input == null) input = new JobVm();
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

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }
        public ActionResult List()
        {
            var results = jobManager.getAll(null);
            return PartialView(results);
        }
        [HttpPost]
        public ActionResult Create(JobVo input)
        {
            JobCategoriesManager jobCategoriesManager = new JobCategoriesManager();
            JobCategoriesVo categoryVo = new JobCategoriesVo();

            if (this.ModelState.IsValid)
            {
                var item = jobManager.insert(input);
                foreach(int categoryId in input.jobCategoryType)
                {
                    categoryVo.jobId = input.jobId;
                    categoryVo.jobCategoryTypeId = categoryId;
                    categoryVo.isActive = true;

                    jobCategoriesManager.insert(categoryVo);
                    categoryVo = new JobCategoriesVo();
                }

                
                return RedirectToAction("Index");
            }


            return View(input);
        }
        public ActionResult Create()
        {
            JobVo vo = new JobVo();
            return View(vo);
        }
        public ActionResult Edit(Guid id)
        {
            JobVo vo = jobManager.get(id);
            if(vo.jobCategories.Count>0)
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
        public ActionResult Details(Guid id)
        {
            var result = jobManager.get(id);
            return View(result);
        }
        public ActionResult Delete(Guid id)
        {
            jobManager.delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Filter(JobVm Input)
        {
            return PartialView("_Filter", Input);
        }
        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
    }
}

using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class JobCategoryType : Controller
    {
        private JobCategoryTypeManager jobCategoryTypeManager = new JobCategoryTypeManager();
        //
        // GET: /jobCategoryType/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("../Jobs/Menu");
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
    }
}

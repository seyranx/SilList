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
        private EntryStatusTypeManager<JobVo> entryStatusTypeManager = new EntryStatusTypeManager<JobVo>();
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

            if (this.ModelState.IsValid)
            {

                var item = jobManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();
        }
        public ActionResult Create()
        {
            JobVo vo = new JobVo();
            return View(vo);
        }
        public ActionResult Edit(Guid id)
        {
            var result = jobManager.get(id);

            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Guid id, JobVo input)
        {
            if (this.ModelState.IsValid)
            {
                var res = jobManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();
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


        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult EntryStatusIndex(EntryStatusTypeVm<JobVo> input = null, Paging paging = null)
        {
            if (input == null)
                input = new EntryStatusTypeVm<JobVo>();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = entryStatusTypeManager.search(input);
                return View(input);
            }
            return View();
        }
        public ActionResult _EntryStatusList()
        {
            var results = entryStatusTypeManager.getAll(null);
            return PartialView(results);
            //return PartialView("_EntryStatusList", results);
        }
        public ActionResult EntryStatusPagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
        public ActionResult EntryStatusFilter(EntryStatusTypeVm<SO.SilList.Manager.Models.ValueObjects.JobVo> input)
        {
            return PartialView("_EntryStatusFilter", input);
        }


        public ActionResult EntryStatusApprove(Guid id)
        {
            var result = entryStatusTypeManager.get(id);
            entryStatusTypeManager.Approve(id);
            return RedirectToAction("EntryStatusIndex");
        }
        public ActionResult EntryStatusDecline(Guid id)
        {
            var result = entryStatusTypeManager.get(id);
            entryStatusTypeManager.Decline(id);
            return RedirectToAction("EntryStatusIndex");
        }
    }
}

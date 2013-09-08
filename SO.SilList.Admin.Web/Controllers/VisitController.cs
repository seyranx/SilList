using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Admin.Web.Controllers
{
    public class VisitController : Controller
    {
        private IVisitManager visitManager = new VisitManager(); 

        public ActionResult Index(VisitVm input = null)
        {
            if (null == input) 
                input = new VisitVm();

            if (null != input.btnSearch)
                input.pageNumber = 1;

            if (this.ModelState.IsValid)
            {
                input = visitManager.search(input);
                
                return View(input);
            }

            return View();
        }

        public ActionResult Filter(VisitVm input)
        {
            return PartialView("_Filter", input);
        }

        public ActionResult Pagination(VisitVm input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Menu()
        {
            return PartialView("../Admin/_Menu");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            if (this.ModelState.IsValid)
            {
                visitManager.delete(DateTime.Parse(collection["oldestDate"]));
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

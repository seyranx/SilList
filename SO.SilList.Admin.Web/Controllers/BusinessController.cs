using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System.Web.Security;

namespace SO.SilList.Admin.Web.Controllers
{
    public class BusinessController : Controller
    {
        private BusinessManager businessManager = new BusinessManager();

          
        public ActionResult Index(BusinessVm input=null)
        {
            var user = Membership.GetUser();
           
            if (input == null)input = new BusinessVm();
            
            if (this.ModelState.IsValid)
            {
                input = businessManager.search(input);
                return View(input);
            }

            return View();

        }
        public ActionResult Filter(BusinessVm input)
        {
            return PartialView("_Filter", input);
        }

         
        [HttpPost]
        public ActionResult Edit(Guid id, BusinessVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = businessManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(Guid id)
        {
            var result = businessManager.get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(BusinessVo input)
        {

            if (this.ModelState.IsValid)
            {
                var item = businessManager.insert(input);

                ImageManager imageManager = new ImageManager();
                imageManager.InsertImageForBusiness(item.businessId, Request.Files, Server);

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Create()
        {
            var vo = new BusinessVo();
            return View(vo);
        }

        public ActionResult Details(Guid id)
        {
            var result = businessManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult Pagination(BusinessVm input = null)
        {
            return PartialView("_Pagination", input);
        }
        

        public ActionResult Delete(Guid id)
        {
            businessManager.delete(id);
            return RedirectToAction("Index");
        }

      
    }
}

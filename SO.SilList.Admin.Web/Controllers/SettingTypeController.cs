using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Admin.Web.Controllers
{
    public class SettingTypeController : Controller
    {

        private SettingTypeManager settingTypeManager = new SettingTypeManager();

        public ActionResult Index(SettingTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new SettingTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = settingTypeManager.search(input);
                return View(input);
            }
            return View();
        }


        public ActionResult List()
        {
            var results = settingTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Edit(int id, SettingTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = settingTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = settingTypeManager.get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(SettingTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = settingTypeManager.insert(input);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Create()
        {
            var vo = new SettingTypeVo();
            return View(vo);
        }

        public ActionResult Details(int id)
        {
            var result = settingTypeManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult Delete(int id)
        {
            settingTypeManager.delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Filter(SettingTypeVm Input)
        {
            return PartialView("_Filter", Input);
        }
        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ViewModels;
using SO.Utility.Classes; 
using SO.Utility.Models.ViewModels;
using SO.Utility;
using SO.Utility.Helpers;
using SO.Utility.Extensions;

namespace  SO.SilList.Admin.Web.Controllers
{
    public class ListingCategoryLookupController : Controller
    {
        private ListingCategoryLookupManager listingCategoryLookupManager = new ListingCategoryLookupManager();


		public ActionResult Index(SearchFilterVm input = null, Paging paging = null)
        {
            if (input == null) input = new SearchFilterVm();
            input.paging = paging;

            if (this.ModelState.IsValid)
            { 
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = listingCategoryLookupManager.search(input);
                return View(input);
            }
            return View(input);
        }

		

        public FileResult Export(SearchFilterVm input = null)
        {

            if (this.ModelState.IsValid)
            {
                input.paging = null;
                input = listingCategoryLookupManager.search(input);
                var file = ImportExportHelper.exportToCsv(input.result);

                return File(file.FullName, "Application/octet-stream", file.Name);
            }

            return null;
        }
		 
	    #region CRUD

		public ActionResult List()
        {
            var results = listingCategoryLookupManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, ListingCategoryLookupVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = listingCategoryLookupManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View(input); 

        }
        public ActionResult Edit(Guid id)
        {
            var result = listingCategoryLookupManager.get(id);
            return View(result); 
        }

        [HttpPost]
        public ActionResult Create(ListingCategoryLookupVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = listingCategoryLookupManager.insert(input);
                return RedirectToAction("Index");
            }


            return View(input);

        }

        public ActionResult Create()
        {
            var vo = new ListingCategoryLookupVo();
            return View(vo);
        }

        public ActionResult Details(Guid id)
        {
            var result = listingCategoryLookupManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult Delete(Guid id)
        {
            listingCategoryLookupManager.delete(id);
            return RedirectToAction("Index");
        }

		#endregion
    }	 
        
    
}


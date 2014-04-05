using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.Utility.Models.ViewModels;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Web.Controllers
{
    public class DropDownController : Controller
    {
        //
        // GET: /DropDown/
        public ActionResult Index()
        {
            return View();
        }
    }
}

namespace SO.Urba.Web.Controllers
{
    [Authorize]
    public class DropDownController : Controller
    {
        private PropertyTypeManager propertyTypeManager = new PropertyTypeManager();
        private PropertyManager propertyManager = new PropertyManager();

        /// <summary>
        /// /DropDown/propertyTypes
        /// 
        ///   @Html.Action("propertyTypes", "DropDown", new { id = Model.propertyTypeId })
        /// </summary>
        public ActionResult propertyTypes(int? id = null)
        {
            var vo = new DropDownVm();
            vo.propertyName = "propertyTypeId";
            vo.dataValueField = "propertyTypeId";
            vo.dataTextField = "name";
            vo.selectedValue = id;
            vo.optionLabel = "Property Types";
            vo.items = propertyTypeManager.getAll(true);

            return View("_DropDownList", vo);
        }

        /// <summary>
        /// /DropDown/companies
        /// 
        ///   @Html.Action("properties", "DropDown", new { id = Model.companyId })
        /// </summary>
        public ActionResult properties(int? id = null)
        {
            var vo = new DropDownVm();
            vo.propertyName = "propertyId";
            vo.dataValueField = "propertyId";
            vo.dataTextField = "companyName";
            vo.selectedValue = id;
            vo.optionLabel = "Properties";
            vo.items = propertyManager.getAll(true);

            return View("_DropDownList", vo);
        }


        ///// <summary>
        /////  /DropDown/companyCategoryTypes2
        /////  
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public ActionResult companyCategoryTypes2(int? id = null)
        //{
        //    var vo = new DropDownVm();
        //    vo.propertyName = "companyCategoryTypeId";
        //    vo.dataValueField = "companyCategoryTypeId";
        //    vo.dataTextField = "name";
        //    vo.selectedValue = id;
        //    vo.optionLabel = "All Providers";
        //    vo.items = companyCategoryTypeManager.getCompanyCategories(true); // CompanyCategoryClass

        //    return View("_DropDownList", vo);
        //}

        
        ///// <summary>
        ///// /DropDown/clients
        ///// 
        /////   @Html.Action("clients", "DropDown", new { id = Model.clientId })
        ///// </summary>
        //public ActionResult clients(int? id = null)
        //{
        //    var vo = new DropDownVm();
        //    vo.propertyName = "clientId";
        //    vo.dataValueField = "clientId";
        //    vo.dataTextField = "clientId";
        //    vo.selectedValue = id;
        //    vo.optionLabel = "All Clients";
        //    vo.items = clientManager.getAll(true);  // CompanyCategoryTypeVo

        //    return View("_DropDownList", vo);
        //}
    }
}
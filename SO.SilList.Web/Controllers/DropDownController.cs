using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.Utility.Models.ViewModels;
using SO.SilList.Manager.Managers;


namespace SO.SilList.Web.Controllers
{
    [Authorize]
    public class DropDownController : Controller
    {
        private PropertyTypeManager propertyTypeManager = new PropertyTypeManager();
        private PropertyManager propertyManager = new PropertyManager();
        private BusinessCategoryTypeManager businessCategoryTypeManager = new BusinessCategoryTypeManager();
        private PropertyListingTypeManager propertyListingTypeManager = new PropertyListingTypeManager();

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

            return View("_DropDown", vo);
        }

        /// <summary>
        /// /DropDown/propertyListingTypes
        /// 
        ///   @Html.Action("propertyListingTypes", "DropDown", new { id = Model.propertyListingTypeId })
        /// </summary>
        public ActionResult propertyListingTypes(int? id = null)
        {
            var vo = new DropDownVm();
            vo.propertyName = "propertyListingTypeId";
            vo.dataValueField = "propertyListingTypeId";
            vo.dataTextField = "name";
            vo.selectedValue = id;
            vo.optionLabel = "Select Type";
            vo.items = propertyListingTypeManager.getAll(true);

            return View("_DropDown", vo);
        }

        /// <summary>
        /// /DropDown/properties
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

            return View("_DropDown", vo);
        }


        /// <summary>
        /// /DropDown/businessCategoryTypes
        /// 
        ///   @Html.Action("propertyTypes", "DropDown", new { id = Model.businessCategoryTypeId })
        /// </summary>
        public ActionResult businessCategoryTypes(int? id = null)
        {
            var vo = new DropDownVm();
            vo.propertyName = "businessCategoryTypeId";
            vo.dataValueField = "businessCategoryTypeId";
            vo.dataTextField = "name";
            vo.selectedValue = id;
            vo.optionLabel = "All Categoies";
            vo.items = businessCategoryTypeManager.getAll(true); 

            return View("_DropDownList", vo);
        }

        
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
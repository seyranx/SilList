using SO.Utility.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.Utility.Models.ViewModels
{
    public class SearchFilterVm
    {

        
        public List<object> result { get; set; }
        public string keyword { get; set; }

        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }
        public string submitButton { get; set; }
        public Paging paging;


        //
        public int? filter_cityTypeId { get; set; }
        public int? filter_zip { get; set; }
        public int? listingDate { get; set; }
        //
        public int? propertyListingTypeId { get; set; }
        public int? propertyTypeId { get; set; }
        // 
       

        public SearchFilterVm()
        {
            this.result = new List<object>();
            if (paging == null)
                paging = new Paging();
        }
    }
}
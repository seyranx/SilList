using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class JobVm
    {
        public List<JobVo> result { get; set; }
        public string keyword { get; set; }
     
        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }
        public string submitButton { get; set; }
        public Paging paging;
       
        public int? jobCategoryId { get; set; }
        public int? cityTypeId { get; set; }
        public int? stateTypeId { get; set; }
        public int? countryTypeId {get;set;}
        public int? listingDate { get; set; }
        public int? zip { get; set; }
        public int? jobTypeId { get; set; }

        //*****
        public bool? showPendingOnly { get; set; } // for Entry Status Type 
 
        public JobVm()
        {
            //pageNumber = 1;
            this.result = new List<JobVo>();

            if(paging==null)
            paging = new Paging();
        }

    }
}


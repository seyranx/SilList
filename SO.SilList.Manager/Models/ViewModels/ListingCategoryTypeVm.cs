using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class ListingCategoryTypeVm
    {
        public List<ListingCategoryTypeVo> result { get; set; }
        public string keyword { get; set; }


        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }
        //  public int totalCount { get; set; }
        public string submitButton { get; set; }
        public Paging paging;

        public ListingCategoryTypeVo listingCategoryType { get; set; }
        //public List<ImageCheckBoxInfo> imagesToRemove { get; set; }

        public ListingCategoryTypeVm()
        {
            //pageNumber = 1;
            listingCategoryType = new ListingCategoryTypeVo();
            this.result = new List<ListingCategoryTypeVo>();
            if (paging == null)
                paging = new Paging();
        }

        public ListingCategoryTypeVm(ListingCategoryTypeVo input)
        {
            listingCategoryType = input;
            this.result = new List<ListingCategoryTypeVo>();
            if (paging == null)
                paging = new Paging();
        }

    }
}

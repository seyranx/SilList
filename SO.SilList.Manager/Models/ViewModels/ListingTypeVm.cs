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
    public class ListingTypeVm
    {
        public List<ListingTypeVo> result { get; set; }
        public string keyword { get; set; }

        public string submitButton { get; set; }
        public Paging paging;

        public ListingTypeVo listingType { get; set; }
        //public List<ImageCheckBoxInfo> imagesToRemove { get; set; }

        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }

        public ListingTypeVm()
        {
            //pageNumber = 1;
            listingType = new ListingTypeVo();
            this.result = new List<ListingTypeVo>();
            if (paging == null)
                paging = new Paging();
        }

        public ListingTypeVm(ListingTypeVo input)
        {
            listingType = input;
            this.result = new List<ListingTypeVo>();
            if (paging == null)
                paging = new Paging();
        }

    }
}

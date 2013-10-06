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
/*
        public List<ListingCategoryTypeVo> result { get; set; }
        public string keyword { get; set; }
        public int pageNumber { get; set; }
        public int totalRowCount { get; set; }

        [Range(4, 50)]
        public int resultPerPage { get; set; }

        [Range(2, 5)]
        public int pageLinkCount { get; set; }

        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }

        public int skip {
            get
            {
                if (pageNumber == null || pageNumber < 2 || resultPerPage < 1) return 0;

                return ((pageNumber - 1) * resultPerPage);
            }
        }

        public int firstVisibleRow
        {
            get
            {
                return (totalRowCount > 0 ? (pageNumber - 1) * resultPerPage + 1 : 0);
            }
        }

        public int lastVisibleRow
        {
            get
            {
                return Math.Min(pageNumber * resultPerPage, totalRowCount);
            }
        }

        public int totalPages
        {
            get
            {
                //return totalRowCount;
                return (int)Math.Ceiling((double)totalRowCount / resultPerPage);
            }
        }

        public ListingCategoryTypeVm()
        {
            this.result = new List<ListingCategoryTypeVo>();
            this.resultPerPage = 4; //change this to adjust default resultPerPage
            this.pageLinkCount = 2;
            this.pageNumber = 1;
        }
*/
    }
}

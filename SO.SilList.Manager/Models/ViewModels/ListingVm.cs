using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class ListingVm
    {
        public List<ListingVo> result { get; set; }
        public string keyword { get; set; }
        public string location { get; set; } //added

        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }
        //  public int totalCount { get; set; }
        public string submitButton { get; set; }
        public Paging paging;

        public ListingVo listing { get; set; }

        public ListingVm()
        {
            //pageNumber = 1;
            listing = new ListingVo();
            this.result = new List<ListingVo>();
            if (paging == null)
                paging = new Paging();
        }

        public ListingVm(ListingVo input)
        {
            listing = input;
            this.result = new List<ListingVo>();
            if (paging == null)
                paging = new Paging();
        }

        /*
        public void AddCarImageInfo(ImageVo carImageVo, bool isChecked = true)
        {
            if (imagesToRemove == null)
            {
                imagesToRemove = new List<CarImageCheckBoxInfo>();
            }
            CarImageCheckBoxInfo carImgInfo = new CarImageCheckBoxInfo(carImageVo.imageId.ToString(), carImageVo.url);
            imagesToRemove.Add(carImgInfo);

        }
        */

        /*
        public List<ListingVo> result { get; set; }
        public string keyword { get; set; }
        public int pageNumber { get; set; }
        public int totalRowCount { get; set; }

        //these are for Web search
        public int buyOrSell { get; set; }
        public string location { get; set; }
        public int searchCount { get; set; }

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

        public ListingVm()
        {
            this.result = new List<ListingVo>();
            this.resultPerPage = 4; //change this to adjust default resultPerPage
            this.pageLinkCount = 2;
            this.pageNumber = 1;
        }
    */
    }
}

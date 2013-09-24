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
    public class CarImageCheckBoxInfo
    {
        public CarImageCheckBoxInfo()
        {

        }
        public CarImageCheckBoxInfo(string imgIdStr, string imgUrlStr, bool isChecked = true)
        {
            this.imageIdStr = imgIdStr;
            this.imageUrlStr = imgUrlStr;
            this.imageIsChecked = isChecked;
        }
        public string imageIdStr { get; set; }
        public string imageUrlStr { get; set; }
        public bool imageIsChecked { get; set; }
    };

    public class CarVm
    {
        public List<CarVo> result { get; set; }
        public string keyword { get; set; }
        public int? pageNumber { get; set; }

        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }
        public int totalCount { get; set; }
        public string submitButton { get; set; }
        public Paging paging;

        public CarVo car { get; set; }
        public List<CarImageCheckBoxInfo> imagesToRemove { get; set; }

        public CarVm(CarVo input)
        {
            car = input;
            InitPaging();
        }

        public void AddCarImageInfo(ImageVo carImageVo, bool isChecked = true)
        {
            if (imagesToRemove == null)
            {
                imagesToRemove = new List<CarImageCheckBoxInfo>();
            }
            CarImageCheckBoxInfo carImgInfo = new CarImageCheckBoxInfo(carImageVo.imageId.ToString(), carImageVo.url);
            imagesToRemove.Add(carImgInfo);

        }

        public int totalPages
        {
            get
            {
                return (int)Math.Ceiling(totalCount / (Decimal)rowCount);
            }


        }
        public int next10Page
        {
            get
            {
                return (int)Math.Min((int)pageNumber + 10, totalPages);
            }
        }
        public int prev10Page
        {
            get
            {
                if (pageNumber - 10 <= 0)
                    return 1;
                else
                    return (int)(pageNumber - 10);

            }
        }
        public int startingLinkPage
        {
            get
            {
                if (pageNumber > (int)(pageLinkCount / 2))
                {
                    int tmp = (int)pageNumber - (int)(pageLinkCount / 2);
                    if (tmp + pageLinkCount > totalPages)
                        tmp = (totalPages - pageLinkCount);
                    if (tmp <= 0)
                        tmp = 1;
                    return tmp;
                }
                else
                    return 1;
            }
        }
        public int endingLinkPage
        {
            get
            {
                if (startingLinkPage + pageLinkCount > totalPages)
                    return (totalPages - startingLinkPage) + startingLinkPage;
                else
                    return startingLinkPage + pageLinkCount; ;
            }
        }
        public int skip
        {
            get
            {
                if (pageNumber == null || pageNumber < 2 || rowCount < 1) return 0;

                return ((int)(pageNumber - 1) * (int)rowCount);
            }
        }
        public int pageLinkCount
        {
            get
            {
                return 3;
            }
        }
        public int rowCount
        {
            get
            {
                return 2;
            }
        }

        void InitPaging()
        {
            pageNumber = 1;
            this.result = new List<CarVo>();
            paging = new Paging();
        }

        public CarVm()
        {
            car = new CarVo();
            InitPaging();
        }
    }
}

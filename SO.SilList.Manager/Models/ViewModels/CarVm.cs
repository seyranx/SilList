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


        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }
        //  public int totalCount { get; set; }
        public string submitButton { get; set; }
        public Paging paging;

        public CarVo car { get; set; }
        public List<CarImageCheckBoxInfo> imagesToRemove { get; set; }

        public CarVm()
        {
            //pageNumber = 1;
            car = new CarVo();
            this.result = new List<CarVo>();
            if (paging == null)
                paging = new Paging();
        }

        public CarVm(CarVo input)
        {
            car = input;
            this.result = new List<CarVo>();
            if (paging == null)
                paging = new Paging();
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
    }
}


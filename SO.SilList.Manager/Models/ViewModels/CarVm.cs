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
        public List<ImageCheckBoxInfo> imagesToRemove { get; set; }

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
                imagesToRemove = new List<ImageCheckBoxInfo>();
            }
            ImageCheckBoxInfo carImgInfo = new ImageCheckBoxInfo(carImageVo.imageId.ToString(), carImageVo.url);
            imagesToRemove.Add(carImgInfo);

        }
    }
}


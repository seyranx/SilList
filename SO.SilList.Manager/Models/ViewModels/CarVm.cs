using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
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
        public CarImageCheckBoxInfo(string imgIdStr, string imgUrlStr,  bool isChecked = true)
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
        public CarVm()
        {

        }
        public CarVm(CarVo input)
        {
            car = input;
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
        public CarVo car { get; set; }
        public List<CarImageCheckBoxInfo> imagesToRemove { get; set; }
    }
}

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



        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }
        //properties for search
        public string keyword { get; set; }
        public int? site { get; set; }
        //*****
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
    }

}


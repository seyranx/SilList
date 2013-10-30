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
        public Boolean isAdvanceOn { get; set; }
        public string keyword { get; set; }
        public int? site { get; set; }
        private int? _make;
        public int? make
        {
            get{
                return _make;
            }
            set
            {
                model = null;
                _make = value;
            }
        }
        public int? model { get; set; }
        public int? body { get; set; }
        public int? transmission { get; set; }
        public int? engine { get; set; }
        public int? drive { get; set; }
        public int? door { get; set; }
        public int? fuel { get; set; }
        public int? inColor { get; set; }
        public int? exColor { get; set; }
        public int? year { get; set; }
        public int? yearTo { get; set; }
        public string vin { get; set; }
        public int? startingPrice {get;set;}
        public int? endingPrice { get; set; }
        public int? startingMillage {get; set; }
        public int? endingMillage { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int? zip { get; set; }
        public int? listigDate { get; set; }
        //*****
        public string submitButton { get; set; }
        public Paging paging;

        public CarVo car { get; set; }
        public List<ImageCheckBoxInfo> imagesToRemove { get; set; }

        public CarVm()
        {
            //pageNumber = 1;
            isAdvanceOn = false;
            car = new CarVo();
            this.result = new List<CarVo>();
            if (paging == null)
                paging = new Paging();
        }

        public CarVm(CarVo input)
        {
            isAdvanceOn = false;
            car = input;
            this.result = new List<CarVo>();
            if (paging == null)
                paging = new Paging();
        }
    }

}


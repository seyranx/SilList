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
        public int? siteId { get; set; }
        private int? _makeTypeId;
        public int? makeTypeId
        {
            get{
                return _makeTypeId;
            }
            set
            {
                modelTypeId = null;
                _makeTypeId = value;
            }
        }
        public int? modelTypeId { get; set; }
        public int? bodyTypeId { get; set; }
        public int? transmissionTypeId { get; set; }
        public int? engineTypeId { get; set; }
        public int? driveTypeId { get; set; }
        public int? doorTypeId { get; set; }
        public int? fuelTypeId { get; set; }
        public int? inColorTypeId { get; set; }
        public int? exColorTypeId { get; set; }
        public int? year { get; set; }
        public int? yearTo { get; set; }
        public string vin { get; set; }
        public int? startingPrice {get;set;}
        public int? endingPrice { get; set; }
        public int? startingMillage {get; set; }
        public int? endingMillage { get; set; }
        public int? cityTypeId { get; set; }
        public int? stateTypeId { get; set; }
        public int? zip { get; set; }
        public int? listingDate { get; set; }
        //*****
        public string submitButton { get; set; }
        public Paging paging;
        //*****
        public bool? showPendingOnly { get; set; } // for Entry Status Type 

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


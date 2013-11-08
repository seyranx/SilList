using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class RentalVm
    {
        public List<PropertyVo> result { get; set; }
        public string keyword { get; set; }
        public string location { get; set; }

        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }
        public string submitButton { get; set; }
        public Paging paging;

        public PropertyVo rental { get; set; }
        public List<ImageCheckBoxInfo> imagesToRemove { get; set; }

        public RentalVm()
        {
            rental = new PropertyVo();
            this.result = new List<PropertyVo>();
            if (paging == null)
                paging = new Paging();
        }

        public RentalVm(PropertyVo input)
        {
            rental = input;
            this.result = new List<PropertyVo>();
            if (paging == null)
                paging = new Paging();
        }

    }
}

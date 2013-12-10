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
    public class AcceptsSection8TypeVm
    {
        public List<AcceptsSection8TypeVo> result { get; set; }
        public string keyword { get; set; }

        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }
        public string submitButton { get; set; }
        public Paging paging;

        public AcceptsSection8TypeVm()
        {
            this.result = new List<AcceptsSection8TypeVo>();

            if (paging == null)
                paging = new Paging();
        }
    }
}

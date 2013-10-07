using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SO.SilList.Utility.Classes;


namespace SO.SilList.Manager.Models.ViewModels
{
    public class ServiceTypeVm
    {
        public List<ServiceTypeVo> result { get; set; }
        public string keyword { get; set; }
        public string submitButton { get; set; }
        public Paging paging;

        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }


        public ServiceTypeVm()
        {
            this.result = new List<ServiceTypeVo>();
            if (paging == null)
                paging = new Paging();
        }
    }
}


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
    public class JobTypeVm
    {
        public List<JobTypeVo> result { get; set; }
        public string keyword { get; set; }
     
        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }
        public string submitButton { get; set; }
        public Paging paging;

        public JobTypeVm()
        {
            //pageNumber = 1;
            this.result = new List<JobTypeVo>();

            if(paging==null)
            paging = new Paging();
        }

    }
}


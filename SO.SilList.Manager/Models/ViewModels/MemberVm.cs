using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class MemberVm
    {
     
        public List<MemberVo> result { get; set; }
        public string keyword { get; set; }
        public string submitButton { get; set; }
        public Paging paging;

        [DisplayName("Is Active: ")]
        public bool? filterIsActive { get; set; }


        public MemberVm()
        {
            this.result = new List<MemberVo>();
            if (paging == null)
                paging = new Paging();
        }

    }
}

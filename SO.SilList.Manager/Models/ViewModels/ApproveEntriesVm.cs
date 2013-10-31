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
    // todo: change Job to be generic (or implement for job,listing, and any other component that has isApproved field)
    public class ApproveEntriesVm
    {
        public List<JobVo> result { get; set; } // TODO: make it for Jobs for now. Will extend to other types or make generic later
        public string keyword { get; set; }

        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }
        public string submitButton { get; set; }
        public Paging paging;

        public ApproveEntriesVm()
        {
            this.result = new List<JobVo>();
            if (paging == null)
                paging = new Paging();
        }
    }
}

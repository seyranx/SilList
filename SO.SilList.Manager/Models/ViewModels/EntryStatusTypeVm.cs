using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Classes;

namespace SO.SilList.Manager.Models.ViewModels
{
    // todo: change Job to be generic (or implement for job,listing, and any other component that has isApproved field)
    public class EntryStatusTypeVm
    {
        public EntryStatusTypeVo entryStatusType { get; set; }
        public EntryStatusTypeVm(EntryStatusTypeVo input)
        {
            entryStatusType = input;
        }
        public List<JobVo> result { get; set; } // todo: jobVo to be replace to be generic or something
        public string keyword { get; set; }

        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }
        public string submitButton { get; set; }
        public Paging paging;

        public EntryStatusTypeVm()
        {
            this.result = new List<JobVo>();
            if (paging == null)
                paging = new Paging();
        }
    }
}

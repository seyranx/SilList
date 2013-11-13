using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class EntryStatusTypeVm
    {
        public EntryStatusTypeVm()
        {
            entryStatusType = new EntryStatusTypeVo();
        }
        public EntryStatusTypeVm(EntryStatusTypeVo input)
        {
            entryStatusType = input;
        }
        public EntryStatusTypeVo entryStatusType { get; set; }
    }

}

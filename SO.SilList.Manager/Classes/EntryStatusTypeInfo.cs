using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Classes
{
    // todo: JobVo to be replaced to something generic to represent Job, business and all other tables that had isApproved field
    public class EntryStatusTypeInfo
    {
        public enum EntryStatusTypeConst { cPending, cApproved, cDeclined };

        public EntryStatusTypeInfo() { statusType = EntryStatusTypeConst.cPending; }
        public EntryStatusTypeInfo(JobVo input_job, EntryStatusTypeConst status)
        {
            job = input_job;
            statusType = status;
        }
        JobVo job;  // TODO: make it for Jobs for now. Will extend to other types or make generic later
        EntryStatusTypeConst statusType;
    }
}

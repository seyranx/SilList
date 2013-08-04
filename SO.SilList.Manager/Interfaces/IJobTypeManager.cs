using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SO.SilList.Manager.Interfaces
{
    interface IJobTypeManager
    {
        JobTypeVo get(int jobTypeId);
        List<JobTypeVo> getAll(bool? isActive = true);
        bool delete(int jobTypeId);
        JobTypeVo update(JobTypeVo input, int? jobTypeId = null);
        JobTypeVo insert(JobTypeVo input);
    }
}

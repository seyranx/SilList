using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IJobCategoryTypeManager
    {
        JobCategoryTypeVo get(int jobcategoryTypeId);
        List<JobCategoryTypeVo> getAll(bool? isActive = true);
        bool delete(int jobcategoryTypeId);
        JobCategoryTypeVo update(JobCategoryTypeVo input, int? jobcategoryTypeId = null);
        JobCategoryTypeVo insert(JobCategoryTypeVo input);
    }
}

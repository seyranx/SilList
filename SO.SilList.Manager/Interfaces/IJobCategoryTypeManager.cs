using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IJobCategoryTypeManager
    {

        JobCategoryTypeVo get(int jobCategoryTypeId);
        List<JobCategoryTypeVo> getAll(bool? isActive = true);
        bool delete(int jobsCategoryTypeId);
        JobCategoryTypeVo update(JobCategoryTypeVo input, int? jobCategoryTypeId = null);
        JobCategoryTypeVo insert(JobCategoryTypeVo input);
    }
}

using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IJobCategoriesManager
    {
        JobCategoriesVo get(Guid jobCategoriesId);
        List<JobCategoriesVo> getAll(bool? isActive = true);
        bool delete(int jobCategoriesId);
        JobCategoriesVo update(JobCategoriesVo input, Guid? jobCategoriesId = null);
        JobCategoriesVo insert(JobCategoriesVo input);
    }
}

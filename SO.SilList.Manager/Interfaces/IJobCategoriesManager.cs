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
        JobCategoriesVo get(Guid jobcategoriesId);
        List<JobCategoriesVo> getAll(bool? isActive = true);
        bool delete(int jobcategoriesId);
        JobCategoriesVo update(JobCategoriesVo input, Guid? jobcategoriesId = null);
        JobCategoriesVo insert(JobCategoriesVo input);
    }
}

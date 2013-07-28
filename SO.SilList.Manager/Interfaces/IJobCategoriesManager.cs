using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IJobCategoriesManager
    {
        JobCategoriesVo get(int jobcategoriesId);
        List<JobCategoriesVo> getAll(bool? isActive = true);
        bool delete(int jobcategoriesId);
        JobCategoriesVo update(JobCategoriesVo input, int? jobcategoriesId = null);
        JobCategoriesVo insert(JobCategoriesVo input);
    }
}

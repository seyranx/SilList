using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IJobCompanyManager
    {
        JobCompanyVo get(Guid siteId);
        JobCompanyVo getFirst();
        List<JobCompanyVo> getAll(bool? isActive = true);
        bool delete(Guid JobCompanyId);
        JobCompanyVo update(JobCompanyVo input, Guid? JobCompanyId = null);
        JobCompanyVo insert(JobCompanyVo input);
        int count();
    }
}

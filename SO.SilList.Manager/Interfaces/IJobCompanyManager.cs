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
        JobCompanyVo get(int siteId);
        List<JobCompanyVo> getAll(bool? isActive = true);
        bool delete(int JobCompanyId);
        JobCompanyVo update(JobCompanyVo input, int? JobCompanyId = null);
        JobCompanyVo insert(JobCompanyVo input);
    }
}

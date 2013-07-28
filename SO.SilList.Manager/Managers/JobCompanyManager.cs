using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Managers
{
    public class JobCompanyManager :IJobCompanyManager
    {
        public JobCompanyVo get(int jobCompanyId)
        {
            using (var db = new MainDb())
            {
                var result = db.jobCompanys
                            .FirstOrDefault(s => s.jobCompanyId == jobCompanyId);
                return result;
            }
        }

        public List<JobCompanyVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(int jobCompanyId)
        {
            throw new NotImplementedException();
        }

        public JobCompanyVo update(JobCompanyVo input, int? jobCompanyId = null)
        {
            throw new NotImplementedException();
        }

        public JobCompanyVo insert(JobCompanyVo input)
        {
            throw new NotImplementedException();
        }
    }
}

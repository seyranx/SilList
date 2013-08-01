using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.DbContexts;

namespace SO.SilList.Manager.Managers
{
    public class JobCompanyManager :IJobCompanyManager
    {
        public JobCompanyVo get(Guid jobCompanyId)
        {
            using (var db = new MainDb())
            {
                var result = db.jobCompanys
                            .FirstOrDefault(s => s.jobCompanyId == jobCompanyId);
                return result;
            }
        }
        /// <summary>
        /// Get First Item
        /// </summary>
        public JobCompanyVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.jobCompanys
                            .FirstOrDefault();
                return res;
            }
        }


        public List<JobCompanyVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.jobCompanys
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();
                return list;
            }
        }

        public bool delete(Guid jobCompanyId)
        {
            using (var db = new MainDb())
            {
                var res = db.jobCompanys
                     .Where(e => e.jobCompanyId == jobCompanyId)
                     .Delete();
                return true;
            }
        }

        public JobCompanyVo update(JobCompanyVo input, Guid? jobCompanyId = null)
        {
            throw new NotImplementedException();
        }

        public JobCompanyVo insert(JobCompanyVo input)
        {
            throw new NotImplementedException();
        }
    }
}

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
    class JobTypeManager : IJobTypeManager
    {
        public JobTypeVo get(int jobTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.jobTypes
                            .FirstOrDefault(s => s.jobTypeId == jobTypeId);
                return result;
            }
        }

        public List<JobTypeVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(int jobTypeId)
        {
            throw new NotImplementedException();
        }

        public JobTypeVo update(JobTypeVo input, int? jobTypeId = null)
        {
            throw new NotImplementedException();
        }

        public JobTypeVo insert(JobTypeVo input)
        {
            throw new NotImplementedException();
        }
    }
}

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
  public  class JobManager : IJobManager
    {
        public Models.ValueObjects.JobVo get(Guid jobId)
        {
            using (var db = new MainDb())
            {
                var result = db.job
                            .FirstOrDefault(s => s.jobId == jobId);
                return result;
            }
        }

        public List<Models.ValueObjects.JobVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(Guid jobId)
        {
            throw new NotImplementedException();
        }

        public Models.ValueObjects.JobVo update(Models.ValueObjects.JobVo input, Guid? jobId = null)
        {
            throw new NotImplementedException();
        }

        public Models.ValueObjects.JobVo insert(Models.ValueObjects.JobVo input)
        {
            throw new NotImplementedException();
        }
    }
}

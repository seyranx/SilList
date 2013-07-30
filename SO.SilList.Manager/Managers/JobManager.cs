using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Models.ValueObjects;


namespace SO.SilList.Manager.Managers
{
  public  class JobManager : IJobManager
    {
        public Models.ValueObjects.JobVo get(Guid jobId)
        {
            using (var db = new MainDb())
            {
                var result = db.jobs
                            .FirstOrDefault(s => s.jobId == jobId);
                return result;
            }
        }
        public JobVo getFirst()
        {
            using (var db = new MainDb())
            {
                var result = db.jobs
                    /// .Include(s => s.site)
                            .FirstOrDefault();

                return result;
            }
        }

        public List<JobVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.jobs
                    ///.Include(s => s.site)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(Guid jobId)
        {
            using (var db = new MainDb())
            {
                var res = db.jobs
                     .Where(e => e.jobId == jobId)
                     .Delete();
                return true;
            }
        }

        public JobVo update(JobVo input, Guid? jobId = null)
        {
            using (var db = new MainDb())
            {
                if (jobId == null)
                    jobId = input.jobId;

                var result = db.jobs.FirstOrDefault(e => e.jobId == jobId);

                if (result == null) return null;

                input.created = result.created;
                input.createdBy = result.createdBy;
                db.Entry(result).CurrentValues.SetValues(input);

                db.SaveChanges();
                return result;

            }
        }

        public JobVo insert(JobVo input)
        {
            using (var db = new MainDb())
            {
                db.jobs.Add(input);
                db.SaveChanges();

                return input;
            }
        }
        public int count()
        {
            using (var db = new MainDb())
            {
                return db.jobs.Count();
            }
        }
    }
}

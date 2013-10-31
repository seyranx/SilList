using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Manager.Models.ValueObjects;

using System.Data.Entity;
using EntityFramework.Extensions;


namespace SO.SilList.Manager.Managers
{
    public class ApproveEntriesManager
    {
       public Models.ValueObjects.JobVo get(Guid jobId)
        {
            using (var db = new MainDb())
            {
                var result = db.jobs
                            //.Include(s => s.site)
                            //.Include(j => j.jobType)
                            //.Include(t => t.jobCompany)
                            //.Include(i => i.cityType)
                            //.Include(o => o.countryType)
                            //.Include(u => u.stateType) 

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
        public ApproveEntriesVm search(ApproveEntriesVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.jobs
                            // .Include(s => s.site)
                            // .Include(j => j.jobType)
                            // .Include(t => t.jobCompany)
                            //.Include(i => i.cityType)
                            //.Include(o => o.countryType)
                            //.Include(u => u.stateType) 

                            .OrderBy(b => b.title)
                            .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.title.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                             );
                input.paging.totalCount = query.Count();
                input.result = query
                             .Skip(input.paging.skip)
                             .Take(input.paging.rowCount)

                             .ToList();

                return input;
            }
        }

        public List<JobVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.jobs
                            // .Include(s => s.site)
                            // .Include(j => j.jobType)
                            // .Include(t => t.jobCompany)
                            //.Include(i => i.cityType)
                            //.Include(o => o.countryType)
                            //.Include(u => u.stateType) 

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

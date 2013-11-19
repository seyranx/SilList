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
using SO.SilList.Manager.Classes;


namespace SO.SilList.Manager.Managers
{
    public class EntryStatusTypeStrings
    {
        public const String csPending = "Pending";
        public const String csApprove = "Approved";
        public const String csDecline = "Declined";
    }

    public class EntryStatusTypeManager<T>
    {
        //public T get<T>(Guid id)
        //{
        //    return default(T);
        //}

        ///// <summary>
        ///// Find Businesses matching the businessId (primary key)
        ///// </summary>
        //public BusinessVo get(Guid businessId)
        //{
        //    using (var db = new MainDb())
        //    {
        //        var res = db.businesses
        //                    .Include(s => s.site)
        //                    .Include(i => i.cityType)
        //                    .Include(o => o.countryType)
        //                    .Include(u => u.stateType)

        //                    .FirstOrDefault(p => p.businessId == businessId);

        //        return res;
        //    }
        //}

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
        public EntryStatusTypeVm<JobVo> search(EntryStatusTypeVm<JobVo> input)
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
                    .Include(b => b.entryStatusType)
                            .OrderBy(b => b.title)
                            .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.title.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword)
                                      && e.entryStatusType.name.Equals("Pending")
                                   )
                             );
                input.paging.totalCount = query.Count();
                List<JobVo> jobList = new List<JobVo>();
                input.result = query
                              .Skip(input.paging.skip)
                              .Take(input.paging.rowCount)
                             .ToList();

                return input;
            }
        }
        public EntryStatusTypeVm<BusinessVo> search(EntryStatusTypeVm<BusinessVo> input)
        {
            using (var db = new MainDb())
            {

                var query = db.businesses
                    // .Include(s => s.site)
                    //.Include(i => i.cityType)
                    //.Include(o => o.countryType)
                    //.Include(u => u.stateType)
                    .Include(b => b.entryStatusType)

                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.name.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                                      && e.entryStatusType.name.Equals("Pending")
                                    )
                             .OrderBy(b => b.name);
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

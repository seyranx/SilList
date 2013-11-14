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
using SO.SilList.Manager.Models.ViewModels;


namespace SO.SilList.Manager.Managers
{
  public  class JobManager : IJobManager
    {
        public Models.ValueObjects.JobVo get(Guid jobId)
        {
            using (var db = new MainDb())
            {
                var result = db.jobs
                            .Include(s => s.site)
                            .Include(j => j.jobType)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 
                            .Include(c => c.jobCategories)
                            
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
        public JobVm search(JobVm input)
        {
            JobCategoriesManager jobCategoriesManager = new JobCategoriesManager();


            DateTime listingDate = new DateTime();
            listingDate = DateTime.Today.Date;
            if (input.listingDate != null)
            {
                switch (input.listingDate)
                {
                    case 0: //last 1 day
                        listingDate = listingDate.Subtract(new TimeSpan(1, 0, 0, 0, 0));
                        break;
                    case 1: //last 3 days
                        listingDate = listingDate.Subtract(new TimeSpan(3, 0, 0, 0, 0));
                        break;
                    case 2: //last 7 days
                        listingDate = listingDate.Subtract(new TimeSpan(7, 0, 0, 0, 0));
                        break;
                    case 3: //2 weeks
                        listingDate = listingDate.Subtract(new TimeSpan(14, 0, 0, 0, 0));
                        break;
                    case 4: // last month
                        listingDate = listingDate.Subtract(new TimeSpan(31, 0, 0, 0, 0));
                        break;
                    case 5: // last Two month
                        listingDate = listingDate.Subtract(new TimeSpan(62, 0, 0, 0, 0));
                        break;
                }
            }
            using (var db = new MainDb())
            {
                var query = db.jobs
                             .Include(s => s.site)
                             .Include(j => j.jobType)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType)
                            .Include(c => c.jobCategories)
                            .OrderByDescending(b => b.startDate)
                            .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                && (input.jobTypeId == null || e.jobTypeId == input.jobTypeId)
                                && (input.jobCategoryId == null ||  e.jobCategories.Any(c => (c.jobCategoryTypeId == input.jobCategoryId )))
                                && (input.cityTypeId == null || e.cityTypeId == input.cityTypeId)
                                && (input.stateTypeId == null || e.stateTypeId == input.stateTypeId)
                                && (input.countryTypeId == null || e.countryTypeId == input.countryTypeId)
                                && (input.listingDate == null || DateTime.Compare(e.startDate, listingDate) >= 0)      
                                && (e.title.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword)
                                || e.jobType.name.Contains(input.keyword)
                                || e.companyName.Contains(input.keyword)
                                || e.description.Contains(input.keyword)
                                || e.address.Contains(input.keyword)
                                || e.website.Contains(input.keyword)
                                || e.jobType.name.Contains(input.keyword)
                                || System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)e.zip).Contains(input.keyword))
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
                             .Include(s => s.site)
                             .Include(j => j.jobType)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType)
                             .OrderBy(b => b.startDate)
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

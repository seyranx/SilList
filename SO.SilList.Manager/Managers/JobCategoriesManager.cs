using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Manager.Managers
{
   public class JobCategoriesManager: IJobCategoriesManager
    {
        public JobCategoriesManager()
        {

        }
        /// <summary>
        /// Find 'Job Categories'
        /// </summary>
        public JobCategoriesVo get(Guid jobCategoriesId)
        {
            using (var db = new MainDb())
            {
                var res = db.jobCategories
                            .Include(j => j.job)
                            .Include(s => s.jobCategoryType)
                            .FirstOrDefault(p => p.jobCategoriesId == jobCategoriesId);

                return res;
            }
        }

        public JobCategoriesVm search(JobCategoriesVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.jobCategories
                             .Include(j => j.job)
                             .Include(s => s.jobCategoryType)
                            .OrderBy(b => b.job.description)
                            .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.job.description.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                             );
                input.paging.totalCount = query.Count();
                input.result = query
                             .Skip(input.paging.skip)
                             .Take(input.paging.rowCount)

                             .ToList();

                return input;
            }
        }

        /// <summary>
        /// Get All items
        /// </summary>
        public List<JobCategoriesVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.jobCategories
                             .Include(j => j.job)
                             .Include(s => s.jobCategoryType)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public JobCategoriesVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.jobCategories
                            //.Include(s => s.site)
                            .FirstOrDefault();

                return res;
            }
        }

        /// <summary>
        /// Delete item given the ratingID
        /// </summary>
        public bool delete(Guid jobCategoriesId)
        {
            using (var db = new MainDb())
            {
                var res = db.jobCategories
                     .Where(e => e.jobCategoriesId == jobCategoriesId)
                     .Delete();
                return true;
            }
        }

        /// <summary>
        /// update the table
        /// </summary>
        public JobCategoriesVo update(JobCategoriesVo input, Guid? jobCategoriesId = null)
        {
            using (var db = new MainDb())
            {

                if (jobCategoriesId == null)
                    jobCategoriesId = input.jobCategoriesId;

                var res = db.jobCategories.FirstOrDefault(e => e.jobCategoriesId == jobCategoriesId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public JobCategoriesVo insert(JobCategoriesVo input)
        {
            using (var db = new MainDb())
            {

                db.jobCategories.Add(input);
                db.SaveChanges();

                return input;
            }
        }

    }
}

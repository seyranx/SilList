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
namespace SO.SilList.Manager.Managers
{
    public class JobCategoriesManager : IJobCategoriesManager
    {

        /// <summary>
        /// Find 'BusinessCategories'
        /// </summary>
        public JobCategoriesVo get(int jobCategoryTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.jobCategories
                    //.Include(s => s.site)
                            .FirstOrDefault(p => p.jobCategoryTypeId == jobCategoryTypeId);

                return res;
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
                    //.Include(s => s.site)
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
        public bool delete(int jobCategoryTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.jobCategories
                     .Where(e => e.jobCategoryTypeId == jobCategoryTypeId)
                     .Delete();
                return true;
            }
        }

        /// <summary>
        /// update the table
        /// </summary>
        public JobCategoriesVo update(JobCategoriesVo input, int? jobCategoryTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (jobCategoryTypeId == null)
                    jobCategoryTypeId = input.jobCategoryTypeId;

                var res = db.jobCategories.FirstOrDefault(e => e.jobCategoryTypeId == jobCategoryTypeId);

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

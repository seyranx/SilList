using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using EntityFramework.Extensions;
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

        /// <summary>
        /// Get First Item
        /// </summary>
        public JobTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.jobTypes
                            .FirstOrDefault();
                return res;
            }
        }

        public List<JobTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.jobTypes
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();
                return list;
            }
        }

        public bool delete(int jobTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.jobTypes
                     .Where(e => e.jobTypeId == jobTypeId)
                     .Delete();
                return true;
            }
        }

        public JobTypeVo update(JobTypeVo input, int? jobTypeId = null)
        {
            using (var db = new MainDb())
            {
                if (jobTypeId == null)
                    jobTypeId = input.jobTypeId;

                var res = db.jobTypes.FirstOrDefault(e => e.jobTypeId == jobTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                db.SaveChanges();
                return res;
            }
        }

        public JobTypeVo insert(JobTypeVo input)
        {
            using (var db = new MainDb())
            {
                db.jobTypes.Add(input);
                db.SaveChanges();

                return input;
            }
        }
        public int count()
        {
            using (var db = new MainDb())
            {
                return db.jobTypes.Count();
            }
        }
    }
}

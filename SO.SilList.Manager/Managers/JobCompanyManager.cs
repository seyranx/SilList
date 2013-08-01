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
            using (var db = new MainDb())
            {
                if (jobCompanyId == null)
                    jobCompanyId = input.jobCompanyId;

                var res = db.jobCompanys.FirstOrDefault(e => e.jobCompanyId == jobCompanyId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                db.SaveChanges();
                return res;
            }
        }

        public JobCompanyVo insert(JobCompanyVo input)
        {
            using (var db = new MainDb())
            {
                db.jobCompanys.Add(input);
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

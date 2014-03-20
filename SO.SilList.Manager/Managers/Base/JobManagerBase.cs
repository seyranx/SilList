using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks; 
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Models.ValueObjects; 
using SO.SilList.DbContexts;
using SO.Utility.Models.ViewModels;
using SO.Utility;
using SO.Utility.Helpers;
using SO.Utility.Extensions;
 

namespace  SO.SilList.Managers.Base
{
    public class JobManagerBase
    {

        public JobManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find Job matching the jobId (primary key)
        /// </summary>
        public JobVo get(Guid  jobId )
        {
            using (var db = new MainDb())
            {
                var res = db.jobs
                            .FirstOrDefault(p => p.jobId == jobId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public JobVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.jobs
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.jobs
                             .OrderByDescending(b => b.created)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.title.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                                    );
             
			  if (input.paging != null) { 
					 input.paging.totalCount = query.Count();
					 query =query
                             .Skip(input.paging.skip)
                             .Take(input.paging.rowCount);
                            
				 }
                
                input.result = query.ToList<object>();
				 
                return input;
            }
        }

        //
        public List<JobVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.jobs
                             .Where(e => isActive==null || e.isActive == isActive )
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

        public JobVo update(JobVo input, Guid? jobId= null)
        {
        
            using (var db = new MainDb())
            {

                if (jobId == null)
                    jobId = input.jobId; 

                var res = db.jobs.FirstOrDefault(e => e.jobId == jobId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

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


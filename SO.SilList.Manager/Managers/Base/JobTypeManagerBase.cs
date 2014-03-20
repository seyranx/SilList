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
    public class JobTypeManagerBase
    {

        public JobTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find JobType matching the jobTypeId (primary key)
        /// </summary>
        public JobTypeVo get(int  jobTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.jobTypes
                            .FirstOrDefault(p => p.jobTypeId == jobTypeId);
                  
                return res;
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

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.jobTypes
                             .OrderByDescending(b => b.created)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.name.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
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
        public List<JobTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.jobTypes
                             .Where(e => isActive==null || e.isActive == isActive )
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

        public JobTypeVo update(JobTypeVo input, int? jobTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (jobTypeId == null)
                    jobTypeId = input.jobTypeId; 

                var res = db.jobTypes.FirstOrDefault(e => e.jobTypeId == jobTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
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


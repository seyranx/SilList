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
    public class JobCategoryLookupManagerBase
    {

        public JobCategoryLookupManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find JobCategoryLookup matching the jobCategoryLookupId (primary key)
        /// </summary>
        public JobCategoryLookupVo get(Guid  jobCategoryLookupId )
        {
            using (var db = new MainDb())
            {
                var res = db.jobCategoryLookups
                            .FirstOrDefault(p => p.jobCategoryLookupId == jobCategoryLookupId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public JobCategoryLookupVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.jobCategoryLookups
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.jobCategoryLookups
                             .OrderByDescending(b => b.created)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.jobId.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
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
        public List<JobCategoryLookupVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.jobCategoryLookups
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(Guid jobCategoryLookupId)
        {
            using (var db = new MainDb())
            {
                var res = db.jobCategoryLookups
                     .Where(e => e.jobCategoryLookupId == jobCategoryLookupId)
                     .Delete();
                return true;
            } 
        } 

        public JobCategoryLookupVo update(JobCategoryLookupVo input, Guid? jobCategoryLookupId= null)
        {
        
            using (var db = new MainDb())
            {

                if (jobCategoryLookupId == null)
                    jobCategoryLookupId = input.jobCategoryLookupId; 

                var res = db.jobCategoryLookups.FirstOrDefault(e => e.jobCategoryLookupId == jobCategoryLookupId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public JobCategoryLookupVo insert(JobCategoryLookupVo input)
        {
            using (var db = new MainDb())
            {
                
                db.jobCategoryLookups.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.jobCategoryLookups.Count();
            }
        }
		 
        
    }
}


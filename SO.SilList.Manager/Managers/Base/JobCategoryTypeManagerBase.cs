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
    public class JobCategoryTypeManagerBase
    {

        public JobCategoryTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find JobCategoryType matching the jobCategoryTypeId (primary key)
        /// </summary>
        public JobCategoryTypeVo get(int  jobCategoryTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.jobCategoryTypes
                            .FirstOrDefault(p => p.jobCategoryTypeId == jobCategoryTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public JobCategoryTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.jobCategoryTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.jobCategoryTypes
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
        public List<JobCategoryTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.jobCategoryTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int jobCategoryTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.jobCategoryTypes
                     .Where(e => e.jobCategoryTypeId == jobCategoryTypeId)
                     .Delete();
                return true;
            } 
        } 

        public JobCategoryTypeVo update(JobCategoryTypeVo input, int? jobCategoryTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (jobCategoryTypeId == null)
                    jobCategoryTypeId = input.jobCategoryTypeId; 

                var res = db.jobCategoryTypes.FirstOrDefault(e => e.jobCategoryTypeId == jobCategoryTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public JobCategoryTypeVo insert(JobCategoryTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.jobCategoryTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.jobCategoryTypes.Count();
            }
        }
		 
        
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks; 
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ValueObjects; 
using SO.SilList.Manager.DbContexts;

using SO.Utility.Classes; 
using SO.Utility.Models.ViewModels;
using SO.Utility;
using SO.Utility.Helpers;
using SO.Utility.Extensions;



 

namespace  SO.SilList.Manager.Managers.Base
{
    public class BusinessCategoryTypeManagerBase
    {

        public BusinessCategoryTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find BusinessCategoryType matching the businessCategoryTypeId (primary key)
        /// </summary>
        public BusinessCategoryTypeVo get(int  businessCategoryTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.businessCategoryTypes
                            .FirstOrDefault(p => p.businessCategoryTypeId == businessCategoryTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public BusinessCategoryTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.businessCategoryTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.businessCategoryTypes
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
        public List<BusinessCategoryTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.businessCategoryTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int businessCategoryTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessCategoryTypes
                     .Where(e => e.businessCategoryTypeId == businessCategoryTypeId)
                     .Delete();
                return true;
            } 
        } 

        public BusinessCategoryTypeVo update(BusinessCategoryTypeVo input, int? businessCategoryTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (businessCategoryTypeId == null)
                    businessCategoryTypeId = input.businessCategoryTypeId; 

                var res = db.businessCategoryTypes.FirstOrDefault(e => e.businessCategoryTypeId == businessCategoryTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public BusinessCategoryTypeVo insert(BusinessCategoryTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.businessCategoryTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.businessCategoryTypes.Count();
            }
        }
		 
        
    }
}


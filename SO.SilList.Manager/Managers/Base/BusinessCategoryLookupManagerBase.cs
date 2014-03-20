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
    public class BusinessCategoryLookupManagerBase
    {

        public BusinessCategoryLookupManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find BusinessCategoryLookup matching the businessCategoryLookupId (primary key)
        /// </summary>
        public BusinessCategoryLookupVo get(Guid  businessCategoryLookupId )
        {
            using (var db = new MainDb())
            {
                var res = db.businessCategoryLookups
                            .FirstOrDefault(p => p.businessCategoryLookupId == businessCategoryLookupId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public BusinessCategoryLookupVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.businessCategoryLookups
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.businessCategoryLookups
                             .OrderByDescending(b => b.created)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.businessId.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
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
        public List<BusinessCategoryLookupVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.businessCategoryLookups
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(Guid businessCategoryLookupId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessCategoryLookups
                     .Where(e => e.businessCategoryLookupId == businessCategoryLookupId)
                     .Delete();
                return true;
            } 
        } 

        public BusinessCategoryLookupVo update(BusinessCategoryLookupVo input, Guid? businessCategoryLookupId= null)
        {
        
            using (var db = new MainDb())
            {

                if (businessCategoryLookupId == null)
                    businessCategoryLookupId = input.businessCategoryLookupId; 

                var res = db.businessCategoryLookups.FirstOrDefault(e => e.businessCategoryLookupId == businessCategoryLookupId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public BusinessCategoryLookupVo insert(BusinessCategoryLookupVo input)
        {
            using (var db = new MainDb())
            {
                
                db.businessCategoryLookups.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.businessCategoryLookups.Count();
            }
        }
		 
        
    }
}


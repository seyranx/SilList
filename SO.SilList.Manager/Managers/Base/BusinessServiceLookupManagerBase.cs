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
    public class BusinessServiceLookupManagerBase
    {

        public BusinessServiceLookupManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find BusinessServiceLookup matching the businessServiceLookupId (primary key)
        /// </summary>
        public BusinessServiceLookupVo get(Guid  businessServiceLookupId )
        {
            using (var db = new MainDb())
            {
                var res = db.businessServiceLookups
                            .FirstOrDefault(p => p.businessServiceLookupId == businessServiceLookupId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public BusinessServiceLookupVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.businessServiceLookups
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.businessServiceLookups
                             .OrderByDescending(b => b.created)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.serviceTypeId.ToString().Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
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
        public List<BusinessServiceLookupVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.businessServiceLookups
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(Guid businessServiceLookupId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessServiceLookups
                     .Where(e => e.businessServiceLookupId == businessServiceLookupId)
                     .Delete();
                return true;
            } 
        } 

        public BusinessServiceLookupVo update(BusinessServiceLookupVo input, Guid? businessServiceLookupId= null)
        {
        
            using (var db = new MainDb())
            {

                if (businessServiceLookupId == null)
                    businessServiceLookupId = input.businessServiceLookupId; 

                var res = db.businessServiceLookups.FirstOrDefault(e => e.businessServiceLookupId == businessServiceLookupId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public BusinessServiceLookupVo insert(BusinessServiceLookupVo input)
        {
            using (var db = new MainDb())
            {
                
                db.businessServiceLookups.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.businessServiceLookups.Count();
            }
        }
		 
        
    }
}


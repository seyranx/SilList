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
    public class BusinessManagerBase
    {

        public BusinessManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find Business matching the businessId (primary key)
        /// </summary>
        public BusinessVo get(Guid  businessId )
        {
            using (var db = new MainDb())
            {
                var res = db.businesses
                            .FirstOrDefault(p => p.businessId == businessId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public BusinessVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.businesses
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.businesses
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
        public List<BusinessVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.businesses
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(Guid businessId)
        {
            using (var db = new MainDb())
            {
                var res = db.businesses
                     .Where(e => e.businessId == businessId)
                     .Delete();
                return true;
            } 
        } 

        public BusinessVo update(BusinessVo input, Guid? businessId= null)
        {
        
            using (var db = new MainDb())
            {

                if (businessId == null)
                    businessId = input.businessId; 

                var res = db.businesses.FirstOrDefault(e => e.businessId == businessId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public BusinessVo insert(BusinessVo input)
        {
            using (var db = new MainDb())
            {
                
                db.businesses.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.businesses.Count();
            }
        }
		 
        
    }
}


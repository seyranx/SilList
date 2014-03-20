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
    public class BusinessServiceTypeManagerBase
    {

        public BusinessServiceTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find BusinessServiceType matching the businessServiceTypeId (primary key)
        /// </summary>
        public BusinessServiceTypeVo get(int  businessServiceTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.businessServiceTypes
                            .FirstOrDefault(p => p.businessServiceTypeId == businessServiceTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public BusinessServiceTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.businessServiceTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.businessServiceTypes
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
        public List<BusinessServiceTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.businessServiceTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int businessServiceTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessServiceTypes
                     .Where(e => e.businessServiceTypeId == businessServiceTypeId)
                     .Delete();
                return true;
            } 
        } 

        public BusinessServiceTypeVo update(BusinessServiceTypeVo input, int? businessServiceTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (businessServiceTypeId == null)
                    businessServiceTypeId = input.businessServiceTypeId; 

                var res = db.businessServiceTypes.FirstOrDefault(e => e.businessServiceTypeId == businessServiceTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public BusinessServiceTypeVo insert(BusinessServiceTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.businessServiceTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.businessServiceTypes.Count();
            }
        }
		 
        
    }
}


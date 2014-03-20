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
    public class CityTypeManagerBase
    {

        public CityTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find CityType matching the cityTypeId (primary key)
        /// </summary>
        public CityTypeVo get(int  cityTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.cityTypes
                            .FirstOrDefault(p => p.cityTypeId == cityTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public CityTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.cityTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.cityTypes
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
        public List<CityTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.cityTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int cityTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.cityTypes
                     .Where(e => e.cityTypeId == cityTypeId)
                     .Delete();
                return true;
            } 
        } 

        public CityTypeVo update(CityTypeVo input, int? cityTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (cityTypeId == null)
                    cityTypeId = input.cityTypeId; 

                var res = db.cityTypes.FirstOrDefault(e => e.cityTypeId == cityTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public CityTypeVo insert(CityTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.cityTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.cityTypes.Count();
            }
        }
		 
        
    }
}


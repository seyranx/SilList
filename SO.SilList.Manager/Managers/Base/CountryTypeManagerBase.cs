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
    public class CountryTypeManagerBase
    {

        public CountryTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find CountryType matching the countryTypeId (primary key)
        /// </summary>
        public CountryTypeVo get(int  countryTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.countryTypes
                            .FirstOrDefault(p => p.countryTypeId == countryTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public CountryTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.countryTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.countryTypes
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
        public List<CountryTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.countryTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int countryTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.countryTypes
                     .Where(e => e.countryTypeId == countryTypeId)
                     .Delete();
                return true;
            } 
        } 

        public CountryTypeVo update(CountryTypeVo input, int? countryTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (countryTypeId == null)
                    countryTypeId = input.countryTypeId; 

                var res = db.countryTypes.FirstOrDefault(e => e.countryTypeId == countryTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public CountryTypeVo insert(CountryTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.countryTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.countryTypes.Count();
            }
        }
		 
        
    }
}


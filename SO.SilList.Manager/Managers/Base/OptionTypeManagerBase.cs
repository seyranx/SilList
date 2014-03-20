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
    public class OptionTypeManagerBase
    {

        public OptionTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find OptionType matching the optionTypeId (primary key)
        /// </summary>
        public OptionTypeVo get(int  optionTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.optionTypes
                            .FirstOrDefault(p => p.optionTypeId == optionTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public OptionTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.optionTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.optionTypes
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
        public List<OptionTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.optionTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int optionTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.optionTypes
                     .Where(e => e.optionTypeId == optionTypeId)
                     .Delete();
                return true;
            } 
        } 

        public OptionTypeVo update(OptionTypeVo input, int? optionTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (optionTypeId == null)
                    optionTypeId = input.optionTypeId; 

                var res = db.optionTypes.FirstOrDefault(e => e.optionTypeId == optionTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public OptionTypeVo insert(OptionTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.optionTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.optionTypes.Count();
            }
        }
		 
        
    }
}


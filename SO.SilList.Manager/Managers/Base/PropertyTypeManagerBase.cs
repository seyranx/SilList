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
    public class PropertyTypeManagerBase
    {

        public PropertyTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find PropertyType matching the propertyTypeId (primary key)
        /// </summary>
        public PropertyTypeVo get(int  propertyTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.propertyTypes
                            .FirstOrDefault(p => p.propertyTypeId == propertyTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public PropertyTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.propertyTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.propertyTypes
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
        public List<PropertyTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.propertyTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int propertyTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.propertyTypes
                     .Where(e => e.propertyTypeId == propertyTypeId)
                     .Delete();
                return true;
            } 
        } 

        public PropertyTypeVo update(PropertyTypeVo input, int? propertyTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (propertyTypeId == null)
                    propertyTypeId = input.propertyTypeId; 

                var res = db.propertyTypes.FirstOrDefault(e => e.propertyTypeId == propertyTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public PropertyTypeVo insert(PropertyTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.propertyTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.propertyTypes.Count();
            }
        }
		 
        
    }
}


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
    public class PropertyListingTypeManagerBase
    {

        public PropertyListingTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find PropertyListingType matching the propertyListingTypeId (primary key)
        /// </summary>
        public PropertyListingTypeVo get(int  propertyListingTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.propertyListingTypes
                            .FirstOrDefault(p => p.propertyListingTypeId == propertyListingTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public PropertyListingTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.propertyListingTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.propertyListingTypes
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
        public List<PropertyListingTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.propertyListingTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int propertyListingTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.propertyListingTypes
                     .Where(e => e.propertyListingTypeId == propertyListingTypeId)
                     .Delete();
                return true;
            } 
        } 

        public PropertyListingTypeVo update(PropertyListingTypeVo input, int? propertyListingTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (propertyListingTypeId == null)
                    propertyListingTypeId = input.propertyListingTypeId; 

                var res = db.propertyListingTypes.FirstOrDefault(e => e.propertyListingTypeId == propertyListingTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public PropertyListingTypeVo insert(PropertyListingTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.propertyListingTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.propertyListingTypes.Count();
            }
        }
		 
        
    }
}


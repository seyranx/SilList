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
    public class PropertyManagerBase
    {

        public PropertyManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find Property matching the propertyId (primary key)
        /// </summary>
        public PropertyVo get(Guid  propertyId )
        {
            using (var db = new MainDb())
            {
                var res = db.properties
                            .FirstOrDefault(p => p.propertyId == propertyId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public PropertyVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.properties
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.properties
                             .OrderByDescending(b => b.created)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.title.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
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
        public List<PropertyVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.properties
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(Guid propertyId)
        {
            using (var db = new MainDb())
            {
                var res = db.properties
                     .Where(e => e.propertyId == propertyId)
                     .Delete();
                return true;
            } 
        } 

        public PropertyVo update(PropertyVo input, Guid? propertyId= null)
        {
        
            using (var db = new MainDb())
            {

                if (propertyId == null)
                    propertyId = input.propertyId; 

                var res = db.properties.FirstOrDefault(e => e.propertyId == propertyId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public PropertyVo insert(PropertyVo input)
        {
            using (var db = new MainDb())
            {
                
                db.properties.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.properties.Count();
            }
        }
		 
        
    }
}


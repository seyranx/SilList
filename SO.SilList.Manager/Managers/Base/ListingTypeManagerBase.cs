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
    public class ListingTypeManagerBase
    {

        public ListingTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find ListingType matching the listingTypeId (primary key)
        /// </summary>
        public ListingTypeVo get(int  listingTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.listingTypes
                            .FirstOrDefault(p => p.listingTypeId == listingTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public ListingTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.listingTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.listingTypes
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
        public List<ListingTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.listingTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int listingTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingTypes
                     .Where(e => e.listingTypeId == listingTypeId)
                     .Delete();
                return true;
            } 
        } 

        public ListingTypeVo update(ListingTypeVo input, int? listingTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (listingTypeId == null)
                    listingTypeId = input.listingTypeId; 

                var res = db.listingTypes.FirstOrDefault(e => e.listingTypeId == listingTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public ListingTypeVo insert(ListingTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.listingTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.listingTypes.Count();
            }
        }
		 
        
    }
}


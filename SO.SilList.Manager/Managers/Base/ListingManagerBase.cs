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
    public class ListingManagerBase
    {

        public ListingManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find Listing matching the listingId (primary key)
        /// </summary>
        public ListingVo get(Guid  listingId )
        {
            using (var db = new MainDb())
            {
                var res = db.listings
                            .FirstOrDefault(p => p.listingId == listingId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public ListingVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.listings
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.listings
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
        public List<ListingVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.listings
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(Guid listingId)
        {
            using (var db = new MainDb())
            {
                var res = db.listings
                     .Where(e => e.listingId == listingId)
                     .Delete();
                return true;
            } 
        } 

        public ListingVo update(ListingVo input, Guid? listingId= null)
        {
        
            using (var db = new MainDb())
            {

                if (listingId == null)
                    listingId = input.listingId; 

                var res = db.listings.FirstOrDefault(e => e.listingId == listingId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public ListingVo insert(ListingVo input)
        {
            using (var db = new MainDb())
            {
                
                db.listings.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.listings.Count();
            }
        }
		 
        
    }
}


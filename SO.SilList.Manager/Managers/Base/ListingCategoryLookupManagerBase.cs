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
    public class ListingCategoryLookupManagerBase
    {

        public ListingCategoryLookupManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find ListingCategoryLookup matching the listingCategoryLookupId (primary key)
        /// </summary>
        public ListingCategoryLookupVo get(Guid  listingCategoryLookupId )
        {
            using (var db = new MainDb())
            {
                var res = db.listingCategoryLookups
                            .FirstOrDefault(p => p.listingCategoryLookupId == listingCategoryLookupId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public ListingCategoryLookupVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.listingCategoryLookups
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.listingCategoryLookups
                             .OrderByDescending(b => b.created)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.listingCategoryTypeId.ToString().Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
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
        public List<ListingCategoryLookupVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.listingCategoryLookups
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(Guid listingCategoryLookupId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingCategoryLookups
                     .Where(e => e.listingCategoryLookupId == listingCategoryLookupId)
                     .Delete();
                return true;
            } 
        } 

        public ListingCategoryLookupVo update(ListingCategoryLookupVo input, Guid? listingCategoryLookupId= null)
        {
        
            using (var db = new MainDb())
            {

                if (listingCategoryLookupId == null)
                    listingCategoryLookupId = input.listingCategoryLookupId; 

                var res = db.listingCategoryLookups.FirstOrDefault(e => e.listingCategoryLookupId == listingCategoryLookupId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public ListingCategoryLookupVo insert(ListingCategoryLookupVo input)
        {
            using (var db = new MainDb())
            {
                
                db.listingCategoryLookups.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.listingCategoryLookups.Count();
            }
        }
		 
        
    }
}


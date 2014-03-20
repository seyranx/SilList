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
    public class ListingCategoryTypeManagerBase
    {

        public ListingCategoryTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find ListingCategoryType matching the listingCategoryTypeId (primary key)
        /// </summary>
        public ListingCategoryTypeVo get(int  listingCategoryTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.listingCategoryTypes
                            .FirstOrDefault(p => p.listingCategoryTypeId == listingCategoryTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public ListingCategoryTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.listingCategoryTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.listingCategoryTypes
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
        public List<ListingCategoryTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.listingCategoryTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int listingCategoryTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingCategoryTypes
                     .Where(e => e.listingCategoryTypeId == listingCategoryTypeId)
                     .Delete();
                return true;
            } 
        } 

        public ListingCategoryTypeVo update(ListingCategoryTypeVo input, int? listingCategoryTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (listingCategoryTypeId == null)
                    listingCategoryTypeId = input.listingCategoryTypeId; 

                var res = db.listingCategoryTypes.FirstOrDefault(e => e.listingCategoryTypeId == listingCategoryTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public ListingCategoryTypeVo insert(ListingCategoryTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.listingCategoryTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.listingCategoryTypes.Count();
            }
        }
		 
        
    }
}


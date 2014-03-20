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
    public class ListingStatusTypeManagerBase
    {

        public ListingStatusTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find ListingStatusType matching the listingStatusTypeId (primary key)
        /// </summary>
        public ListingStatusTypeVo get(int  listingStatusTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.listingStatusTypes
                            .FirstOrDefault(p => p.listingStatusTypeId == listingStatusTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public ListingStatusTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.listingStatusTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.listingStatusTypes
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
        public List<ListingStatusTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.listingStatusTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int listingStatusTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingStatusTypes
                     .Where(e => e.listingStatusTypeId == listingStatusTypeId)
                     .Delete();
                return true;
            } 
        } 

        public ListingStatusTypeVo update(ListingStatusTypeVo input, int? listingStatusTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (listingStatusTypeId == null)
                    listingStatusTypeId = input.listingStatusTypeId; 

                var res = db.listingStatusTypes.FirstOrDefault(e => e.listingStatusTypeId == listingStatusTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public ListingStatusTypeVo insert(ListingStatusTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.listingStatusTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.listingStatusTypes.Count();
            }
        }
		 
        
    }
}


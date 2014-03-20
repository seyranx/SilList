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
    public class RatingManagerBase
    {

        public RatingManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find Rating matching the ratingId (primary key)
        /// </summary>
        public RatingVo get(Guid  ratingId )
        {
            using (var db = new MainDb())
            {
                var res = db.ratings
                            .FirstOrDefault(p => p.ratingId == ratingId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public RatingVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.ratings
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.ratings
                             .OrderByDescending(b => b.created)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.review.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
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
        public List<RatingVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.ratings
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(Guid ratingId)
        {
            using (var db = new MainDb())
            {
                var res = db.ratings
                     .Where(e => e.ratingId == ratingId)
                     .Delete();
                return true;
            } 
        } 

        public RatingVo update(RatingVo input, Guid? ratingId= null)
        {
        
            using (var db = new MainDb())
            {

                if (ratingId == null)
                    ratingId = input.ratingId; 

                var res = db.ratings.FirstOrDefault(e => e.ratingId == ratingId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public RatingVo insert(RatingVo input)
        {
            using (var db = new MainDb())
            {
                
                db.ratings.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.ratings.Count();
            }
        }
		 
        
    }
}


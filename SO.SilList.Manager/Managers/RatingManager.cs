using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;


namespace SO.SilList.Manager.Managers
{
    public class RatingManager : IRatingManager
    {
        /// <summary>
        /// Find 'rating' matching the 'ratingId' (primary key)
        /// </summary>
        public RatingVo get(Guid ratingId)
        {
            using (var db = new MainDb())
            {
                var res = db.rating
                            // .Include(s => s.foreignKey)
                            .FirstOrDefault(p=>p.ratingId == ratingId);
                 
                return res;   
            }
        }

        /// <summary>
        /// Get All items
        /// </summary>
        public List<RatingVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.rating
                            // .Include(s => s.foreignKey)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public RatingVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.rating
                            //.Include(s=>s.foreignKey)
                            .FirstOrDefault();
               
                return res;
            }
        }

        /// <summary>
        /// Delete item given the ratingID
        /// </summary>
        public bool delete(Guid ratingId)
        {
            using (var db = new MainDb())
            {
                var res = db.rating
                     //.Include(s=>s.foreignKey)
                     .Where(e => e.ratingId == ratingId)
                     .Delete();
                return true;
            }
        }

        /// <summary>
        /// update the table
        /// </summary>
        public RatingVo update(RatingVo input, Guid? ratingId= null)
        {
            using (var db = new MainDb())
            {
                if (ratingId == null)
                    ratingId = input.ratingId; 

                var res = db.rating.FirstOrDefault(e => e.ratingId == ratingId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;
            }
        }

        public RatingVo insert(RatingVo input)
        {
            using (var db = new MainDb())
            {
                db.rating.Add(input);
                db.SaveChanges();

                return input;
            }
        }

    }
}

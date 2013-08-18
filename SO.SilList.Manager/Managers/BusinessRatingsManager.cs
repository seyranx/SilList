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
    public class BusinessRatingsManager : IBusinessRatingsManager
    {

        public BusinessRatingsManager()
        {

        }
        /// <summary>
        /// Find 'BusinessRating'
        /// </summary>
        public BusinessRatingsVo get(Guid businessRatingId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessRatings
                            .Include(s => s.rating)
                            .Include(b => b.business)
                            .FirstOrDefault(p => p.businessRatingId == businessRatingId);

                return res;
            }
        }

        /// <summary>
        /// Get All items
        /// </summary>
        public List<BusinessRatingsVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.businessRatings
                             .Include(s => s.rating)
                             .Include(b => b.business)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public BusinessRatingsVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.businessRatings
                            //.Include(s => s.site)
                            .FirstOrDefault();

                return res;
            }
        }

        /// <summary>
        /// Delete item given the ratingID
        /// </summary>
        public bool delete(Guid businessRatingId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessRatings
                     .Where(e => e.businessRatingId == businessRatingId)
                     .Delete();
                return true;
            }
        }

        /// <summary>
        /// update the table
        /// </summary>
        public BusinessRatingsVo update(BusinessRatingsVo input, Guid? businessRatingId = null)
        {
            using (var db = new MainDb())
            {

                if (businessRatingId == null)
                    businessRatingId = input.businessRatingId;

                var res = db.businessRatings.FirstOrDefault(e => e.businessRatingId == businessRatingId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public BusinessRatingsVo insert(BusinessRatingsVo input)
        {
            using (var db = new MainDb())
            {

                db.businessRatings.Add(input);
                db.SaveChanges();

                return input;
            }
        }


    }
}

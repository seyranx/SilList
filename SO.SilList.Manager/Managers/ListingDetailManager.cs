using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;

namespace SO.SilList.Manager.Managers
{
    public class ListingDetailManager : IListingDetailManager
    {
        /// <summary>
        /// Find ListingDetail matching the listingDetailId (primary key)
        /// </summary>
        public ListingDetailVo get(Guid listingDetailId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingDetails
                            //.Include(x => x.xxxx)
                            .FirstOrDefault(p => p.listingDetailId == listingDetailId);

                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public ListingDetailVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.listingDetails
                            ///.Include(s => s.site)
                            .FirstOrDefault();

                return res;
            }
        }
        
        public List<ListingDetailVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.listingDetails
                             ///.Include(s => s.site)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(Guid listingDetailId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingDetails
                     .Where(e => e.listingDetailId == listingDetailId)
                     .Delete();
                return true;
            }
        }

        public ListingDetailVo update(ListingDetailVo input, Guid? listingDetailId = null)
        {
            using (var db = new MainDb())
            {
                if (listingDetailId == null)
                    listingDetailId = input.listingDetailId;

                var res = db.listingDetails.FirstOrDefault(e => e.listingDetailId == listingDetailId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                db.SaveChanges();
                return res;

            }
        }

        public ListingDetailVo insert(ListingDetailVo input)
        {
            using (var db = new MainDb())
            {

                db.listingDetails.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.listingDetails.Count();
            }
        }
    }
}
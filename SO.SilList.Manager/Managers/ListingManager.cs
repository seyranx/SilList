using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.DbContexts;

namespace SO.SilList.Manager.Managers
{
    public class ListingManager : IListingManager
    {
        public ListingManager()
        {

        }

        /// Find Listing matching the listingId
        public ListingVo get(Guid listingId)
        {
            using (var db = new MainDb())
            {
                var res = db.listing
                            //.Include(s => s.site)
                            .FirstOrDefault(p => p.listingId == listingId);
                 
                return res;
            }
        }

        /// Get First Item
        public ListingVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.listing
                            //.Include(s=>s.site)
                            .FirstOrDefault();
               
                return res;
            }
        }

        // Get All Items
        public List<ListingVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.listing
                             //.Include(s => s.site)
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }

        // Delete single Item matching listingId
        public bool delete(Guid listingId)
        {
            using (var db = new MainDb())
            {
                var res = db.listing
                     .Where(e => e.listingId == listingId)
                     .Delete();
                return true;
            }
        }

        // Update single Item matching listingId
        public ListingVo update(ListingVo input, Guid? listingId = null)
        {
        
            using (var db = new MainDb())
            {

                if (listingId == null)
                    listingId = input.listingId;

                var res = db.listing.FirstOrDefault(e => e.listingId == listingId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        // Insert Listing
        public ListingVo insert(ListingVo input)
        {
            using (var db = new MainDb())
            {

                db.listing.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        // Count number of Listings
        public int count()
        {
            using (var db = new MainDb())
            {
                return db.listing.Count();
            }
        }

    }
}

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
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Manager.Managers
{
    public class ListingTypeManager : IListingTypeManager
    {
        public ListingTypeManager()
        {

        }

        /// Find ListingType matching the listingTypeId
        public ListingTypeVo get(int listingTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingType
                            //.Include(s => s.site)
                            .FirstOrDefault(p => p.listingTypeId == listingTypeId);
                 
                return res;
            }
        }

        /// Get First Item
        public ListingTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.listingType
                            //.Include(s=>s.site)
                            .FirstOrDefault();
               
                return res;
            }
        }

        // added this method for Search
        public List<ListingTypeVo> search(ListingTypeVm input)
        {

            using (var db = new MainDb())
            {
                var list = db.listingType
                             //.Include(s => s.site)
                             .OrderBy(b => b.name)
                             .Skip(input.skip)
                             .Take(input.rowCount)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.name.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                                    )
                             .ToList();

                return list;
            }
        }

        // Get All Items
        public List<ListingTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.listingType
                             //.Include(s => s.site)
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }

        // Delete single Item matching listingTypeId
        public bool delete(int listingTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingType
                     .Where(e => e.listingTypeId == listingTypeId)
                     .Delete();
                return true;
            }
        }

        // Update single Item matching listingId
        public ListingTypeVo update(ListingTypeVo input, int? listingTypeId = null)
        {
        
            using (var db = new MainDb())
            {

                if (listingTypeId == null)
                    listingTypeId = input.listingTypeId;

                var res = db.listingType.FirstOrDefault(e => e.listingTypeId == listingTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        // Insert Listing
        public ListingTypeVo insert(ListingTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.listingType.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        // Count number of Listings
        public int count()
        {
            using (var db = new MainDb())
            {
                return db.listingType.Count();
            }
        }
    }
}

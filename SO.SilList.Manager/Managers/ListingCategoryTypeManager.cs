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
    public class ListingCategoryTypeManager : IListingCategoryTypeManager
    {
        public ListingCategoryTypeManager()
        {

        }

        /// Find ListingCategoryType matching the listingCategoryTypeId
        public ListingCategoryTypeVo get(int listingCategoryTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingCategoryType
                            //.Include(s => s.site)
                            .FirstOrDefault(p => p.listingCategoryTypeId == listingCategoryTypeId);
                 
                return res;
            }
        }

        /// Get First Item
        public ListingCategoryTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.listingCategoryType
                            //.Include(s=>s.site)
                            .FirstOrDefault();
               
                return res;
            }
        }

        // Get All Items
        public List<ListingCategoryTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.listingCategoryType
                             //.Include(s => s.site)
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }

        // Delete single Item matching listingCategoryTypeId
        public bool delete(int listingCategoryTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingCategoryType
                     .Where(e => e.listingCategoryTypeId == listingCategoryTypeId)
                     .Delete();
                return true;
            }
        }

        // Update single Item matching listingCategoryTypeId
        public ListingCategoryTypeVo update(ListingCategoryTypeVo input, int? listingCategoryTypeId = null)
        {
        
            using (var db = new MainDb())
            {

                if (listingCategoryTypeId == null)
                    listingCategoryTypeId = input.listingCategoryTypeId;

                var res = db.listingCategoryType.FirstOrDefault(e => e.listingCategoryTypeId == listingCategoryTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        // Insert ListingCategoryType
        public ListingCategoryTypeVo insert(ListingCategoryTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.listingCategoryType.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        // Count number of ListingCategoryType
        public int count()
        {
            using (var db = new MainDb())
            {
                return db.listingCategoryType.Count();
            }
        }
    }
}

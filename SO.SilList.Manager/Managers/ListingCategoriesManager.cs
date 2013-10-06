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
    public class ListingCategoriesManager : IListingCategoriesManager
    {
        public ListingCategoriesManager()
        {

        }

        /// Find ListingCategories matching the listingCategoryId
        public ListingCategoriesVo get(Guid listingCategoryId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingCategories
                            .Include(s => s.listingCategoryType) //
                            .FirstOrDefault(p => p.listingCategoryId == listingCategoryId);
                 
                return res;
            }
        }

        /// Get First Item
        public ListingCategoriesVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.listingCategories
                            //.Include(s=>s.site)
                            .FirstOrDefault();
               
                return res;
            }
        }

        public ListingCategoriesVm search(ListingCategoriesVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.listingCategories
                      .Include(s => s.listingCategoryType) 
                            .OrderBy(b => b.listing.description)
                            .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.listing.description.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                             );
                input.paging.totalCount = query.Count();
                input.result = query
                             .Skip(input.paging.skip)
                             .Take(input.paging.rowCount)

                             .ToList();

                return input;
            }
        }

        // Get All Items
        public List<ListingCategoriesVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.listingCategories
                             .Include(s => s.listingCategoryType) // 
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }

        // Delete single Item matching listingCategoryId
        public bool delete(Guid listingCategoryId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingCategories
                     .Where(e => e.listingCategoryId == listingCategoryId)
                     .Delete();
                return true;
            }
        }

        // Update single Item matching listingCategoryId
        public ListingCategoriesVo update(ListingCategoriesVo input, Guid? listingCategoryId = null)
        {
        
            using (var db = new MainDb())
            {

                if (listingCategoryId == null)
                    listingCategoryId = input.listingCategoryId;

                var res = db.listingCategories.FirstOrDefault(e => e.listingCategoryId == listingCategoryId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        // Insert ListingCategory
        public ListingCategoriesVo insert(ListingCategoriesVo input)
        {
            using (var db = new MainDb())
            {

                db.listingCategories.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        // Count number of ListingCategories
        public int count()
        {
            using (var db = new MainDb())
            {
                return db.listingCategories.Count();
            }
        }
    }
}

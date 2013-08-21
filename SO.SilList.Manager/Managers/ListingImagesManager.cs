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
    public class ListingImagesManager : IListingImagesManager
    {
        public ListingImagesManager()
        {

        }

        /// Find ListingImages matching the listingImageId
        public ListingImagesVo get(Guid listingImageId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingImages
                            .Include(s => s.listing)
                            .Include(t => t.image)
                            .FirstOrDefault(p => p.listingImageId == listingImageId);
                 
                return res;
            }
        }

        /// Get First Item
        public ListingImagesVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.listingImages
                            //.Include(s=>s.site)
                            .FirstOrDefault();
               
                return res;
            }
        }

        // Get All Items
        public List<ImageVo> getAllListingImages(bool? isActive = true)
        {
           using (var db = new MainDb())
           {
              var list = (from i in db.images
                          join m in db.listingImages on i.imageId equals m.imageId
                          select i
                          ).ToList();

              return list;
           }
        }
           
        public List<ListingImagesVo> getAll(bool? isActive = true)
        {
           using (var db = new MainDb())
            {
                var list = db.listingImages
                            .Include(s => s.listing)
                            .Include(t => t.image)
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }

        // Delete single Item matching listingImageId
        public bool delete(Guid listingImageId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingImages
                     .Where(e => e.listingImageId == listingImageId)
                     .Delete();
                return true;
            }
        }

        // Update single Item matching listingImageId
        public ListingImagesVo update(ListingImagesVo input, Guid? listingImageId = null)
        {
        
            using (var db = new MainDb())
            {

                if (listingImageId == null)
                    listingImageId = input.listingImageId;

                var res = db.listingImages.FirstOrDefault(e => e.listingImageId == listingImageId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        // Insert ListingImage
        public ListingImagesVo insert(ListingImagesVo input)
        {
            using (var db = new MainDb())
            {

                db.listingImages.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        // Count number of ListingImages
        public int count()
        {
            using (var db = new MainDb())
            {
                return db.listingImages.Count();
            }
        }
    }
}

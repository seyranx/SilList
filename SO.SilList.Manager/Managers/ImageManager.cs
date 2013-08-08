using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Models.ValueObjects;


namespace SO.SilList.Manager.Managers
{
    public class ImageManager : IImageManager
    {
        /// <summary>
        /// Find Image matching the imageId (primary key)
        /// </summary>
        public ImageVo get(Guid imageId)
        {
            using (var db = new MainDb())
            {
                var res = db.images
                            //.Include(s => s...)
                            .FirstOrDefault(p => p.imageId == imageId);

                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public ImageVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.images
                            //.Include(s => s.site)
                            .FirstOrDefault();

                return res;
            }
        }


        public List<ImageVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.images
                             //.Include(s => s.site)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(Guid imageId)
        {
            using (var db = new MainDb())
            {
                var res = db.images
                     .Where(e => e.imageId == imageId)
                     .Delete();
                return true;
            }
        }

        public ImageVo update(ImageVo input, Guid? imageId = null)
        {
            using (var db = new MainDb())
            {
                if (imageId == null)
                    imageId = input.imageId;

                var res = db.images.FirstOrDefault(e => e.imageId == imageId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                db.SaveChanges();
                return res;

            }
        }

        public ImageVo insert(ImageVo input)
        {
            using (var db = new MainDb())
            {
                db.images.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.images.Count();
            }
        }
    }
}

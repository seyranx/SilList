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
using System.Data.SqlClient;


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

        public List<ImageVo> getBusinessImages(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = (from i in db.images
                            join b in db.businessImages on i.imageId equals b.imageId
                            select i
                            ).ToList();

                return list;
            }
        }

        //Seyran Note: RentalImages misses the imageId field
        //
        //public List<ImageVo> getRentalImages(bool? isActive = true)
        //{
        //    using (var db = new MainDb())
        //    {
        //        var list = (from i in db.images
        //                    join r in db.rentalImages on i.imageId equals r.image
        //                    select i
        //                    ).ToList();

        //        return list;
        //    }
        //}

        public List<ImageVo> getCarImages(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = (from i in db.images
                            join c in db.carImages on i.imageId equals c.imageId
                            select i
                            ).ToList();

                return list;
            }
        }

        public List<ImageVo> getListingImages(bool? isActive = true)
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

        //public List<ImageVo> getBusinessImages(bool? isActive = true)
        //{
        //    using (var db = new MainDb())
        //    {
        //        var list = from db.images
        //                     select all from  data.image
        //                         //[data].[image] as c inner join [sillist].[data].[businessimages] as b on  c.imageid = b.imageid

        //                     .Where(e => isActive == null || e.isActive == isActive)
        //                     .ToList();

        //        return list;
        //    }
        //}

        //public List<ImageVo> getBusinessImagesUsingSQL()
        //{
        //    using (var db = new MainDb())
        //    {
        //        //string user = "Admin";
        //        string strSQL = string.Format("SELECT * FROM db.images as c INNER JOIN db.businessImages as b ON  c.imageId = b.imageId");
        //        SqlConnection cnn = new SqlConnection();
        //        using (SqlCommand myCommand = new SqlCommand(strSQL, cnn))
        //        {
        //            var list = new List<ImageVo>();
        //            var reader = myCommand. myCommand.ExecuteReader();
        //            foreach(ImageVo ivo in  reader)
        //            {
        //                list.Add(ivo);
        //            }
        //            return list;
        //        }
        //    }
        //}

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

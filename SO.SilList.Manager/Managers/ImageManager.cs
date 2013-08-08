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

        public List<ImageVo> getBusinessImagesLINQ1(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.images
                    .Include(s => s.site)
                    .Join(db.businessImages, e => e.imageId, b => b.imageId, a => a.name)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        //public List<ImageVo> getBusinessImagesLINQ2(bool? isActive = true)
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

        /*
        1.CannotUnloadAppDomainException Don't know how to get Connection, second param of Sqlcommand
        2.CannotUnloadAppDomainException What is the User name supposed to be ? Admin ??
        3.CannotUnloadAppDomainException reader has only ToString, no ToList
        public List<ImageVo> getBusinessImagesSQL()
        {
            string user = "Admin";
            string strSQL = string.Format("SELECT * FROM [SilList].[data].[Image] as c INNER JOIN [SilList].[data].[BusinessImages] as b ON  c.imageId = b.imageId", user);
            using (SqlCommand myCommand = new SqlCommand(strSQL, db))
            {
                
                var reader = myCommand.ExecuteReader();
                var list = reader.ToList();
                return reader;
            }
        }
        */

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

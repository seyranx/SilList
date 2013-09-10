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
using System.IO;
using System.Web;

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
                            .Include(s => s.site)
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
                             .Include(s => s.site)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

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

        // todo: this version will probably go away soon
        public List<ImageVo> getAllCarImages(bool? isActive = true)
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

        public List<ImageVo> getCarImages(Guid carId)
        {
            using (var db = new MainDb())
            {
                var list = (from i in db.images
                            join c in db.carImages on i.imageId equals c.imageId
                            where c.carId == carId
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

        public List<ImageVo> getRentalImages(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = (from i in db.images
                            join m in db.rentalImages on i.imageId equals m.imageId
                            select i
                            ).ToList();

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////
        // for Edit pages (upload and insert image right away?)
        public void InsertImageAndCarImageIntoDb(Guid carId, string imageName, string imageUrl, string uploadImageAbsFilePath)
        {
            ImageVo imgVo = new ImageVo();
            imgVo.name = imageName;
            imgVo.path = uploadImageAbsFilePath;
            imgVo.url = imageUrl;
            using (var db = new MainDb())
            {
                db.images.Add(imgVo);

                CarImagesVo carImageVo = new CarImagesVo();
                carImageVo.carId = carId;
                carImageVo.imageId = imgVo.imageId;
                db.carImages.Add(carImageVo);

                db.SaveChanges();
            }
        }

        public void InsertImageForCar(Guid id, HttpFileCollectionBase requestFiles,  HttpServerUtilityBase Server)
        {
            /////////////////////////////////////////////////////////////////
            // carImage stuff. todo: need to move to Image controller or whatever ... to reuse from other locations
            /// var id = item.carId;
            string csRelativeBasePath = this.GetBasePathFromConfig();
            string sBaseDir = Path.Combine("~/" + csRelativeBasePath);
            string sDir = Server.MapPath(sBaseDir);

            // todo: need to make sure we have write access to this folder.
            if (!Directory.Exists(sDir))
            {
                Directory.CreateDirectory(sDir);
            }

            if (requestFiles.Count > 0)
            {
                // todo: need to make sure they are uploading image files 
                var UploadImage1 = requestFiles["UploadImage1"];
                var UploadImage2 = requestFiles["UploadImage2"];

                if (UploadImage1 != null && UploadImage1.FileName != null)
                {
                    string fileName1 = Path.GetFileName(UploadImage1.FileName);
                    string fileExtension1 = Path.GetExtension(UploadImage1.FileName);
                    if (!string.IsNullOrEmpty(fileName1) && this.IsImageFile(fileExtension1))
                    {
                        string imageNameOnServer = Guid.NewGuid().ToString() + fileExtension1;
                        string uploadImageAbsFilePath1 = Path.Combine(sDir, imageNameOnServer);
                        UploadImage1.SaveAs(uploadImageAbsFilePath1);
                        string imageUrl = "~/" + this.GetBasePathFromConfig() + "/" + imageNameOnServer;
                        this.InsertImageAndCarImageIntoDb(id, fileName1, imageUrl, uploadImageAbsFilePath1);
                    }
                }
                if (UploadImage2 != null && UploadImage2.FileName != null)
                {
                    string fileName2 = Path.GetFileName(UploadImage2.FileName);
                    string fileExtension2 = Path.GetExtension(UploadImage2.FileName);
                    if (!string.IsNullOrEmpty(fileName2) && this.IsImageFile(fileExtension2))
                    {
                        string imageNameOnServer = Guid.NewGuid().ToString() + fileExtension2;
                        string uploadImageAbsFilePath2 = Path.Combine(sDir, imageNameOnServer);
                        string imageUrl = "~/" + this.GetBasePathFromConfig() + "/" + imageNameOnServer;
                        this.InsertImageAndCarImageIntoDb(id, fileName2, imageUrl, uploadImageAbsFilePath2);
                        UploadImage2.SaveAs(uploadImageAbsFilePath2);
                    }
                }
            }
        }
        /////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.images.Count();
            }
        }

        public string GetBasePathFromConfig()
        {
            // Add a key/value pair in <appSettings> in web.config to override this default value.
            string sRet = "UserUploadedImages";
            string sVal = System.Configuration.ConfigurationManager.AppSettings.Get("UserImagesFolder");
            if (!String.IsNullOrEmpty(sVal))
                sRet = sVal;
            return sRet;
        }

        public bool IsImageFile(string fileExtension)
        {
            // todo: add more or improve this function in general
            return fileExtension == ".jpg"
                || fileExtension == ".bmp"
                || fileExtension == ".png"
                || fileExtension == ".gif";

        }


    }
}

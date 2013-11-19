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
using System.Diagnostics;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Manager.Managers
{
    public class ImageInsertIntoDbInfo
    {
        public ImageInsertIntoDbInfo(Guid id, string fileName, string imgUrl, string uploadImageAbsFilePath)
        {
            this.id = id;
            this.fileName = fileName;
            this.imgUrl = imgUrl;
            this.uploadImageAbsFilePath = uploadImageAbsFilePath;
        }
        public Guid id { get; set; }
        public string fileName { get; set; }
        public string imgUrl { get; set; }
        public string uploadImageAbsFilePath { get; set; }
    }

    public enum ImageCategory { carImage, businessImage, listingImage, propertyImage };

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

        //Seyran Note: PropertyImages misses the imageId field
        //
        //public List<ImageVo> getPropertyImages(bool? isActive = true)
        //{
        //    using (var db = new MainDb())
        //    {
        //        var list = (from i in db.images
        //                    join r in db.propertyImages on i.imageId equals r.image
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

        // used to show given entity's images on Details and Edit pages
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
        public List<string> getCarImagesUrl(Guid carId)
        {
            List<string> list = new List<string>();
            using (var db = new MainDb())
            {
                var imglist = (from i in db.images
                            join c in db.carImages on i.imageId equals c.imageId
                            where c.carId == carId
                            select i
                            ).ToList();
                foreach(var img in imglist)
                {
                    list.Add(img.url);
                }
                return list;
            }
        }
        // used to show given entity's images on Details and Edit pages
        public List<ImageVo> getBusinessImages(Guid businessId)
        {
            using (var db = new MainDb())
            {
                var list = (from i in db.images
                            join c in db.businessImages on i.imageId equals c.imageId
                            where c.businessId == businessId
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

        public List<ImageVo> getPropertyImages((Guid propertyId)
        {
            using (var db = new MainDb())
            {
                var list = (from i in db.images
                            join m in db.propertyImages on i.imageId equals m.imageId
		 	    where c.propertyId == propertyId
                            select i
                            ).ToList();

                return list;
            }
        }
        // used to show given entity's images on Details and Edit pages
        public List<ImageVo> getPropertyImages(Guid propertyId)
        {
            using (var db = new MainDb())
            {
                var list = (from i in db.images
                            join c in db.propertyImages on i.imageId equals c.imageId
                            where c.propertyId == propertyId
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

        // construct ImageInsertIntoDbInfo to use appropriately
        public ImageInsertIntoDbInfo PrepareImageDbInfo(Guid id, HttpFileCollectionBase requestFiles, HttpServerUtilityBase Server, string imageIndex)
        {
            ImageInsertIntoDbInfo ret = null;

            //
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
                var UploadImage = requestFiles[imageIndex];

                if (UploadImage != null && UploadImage.FileName != null)
                {
                    string fileName1 = Path.GetFileName(UploadImage.FileName);
                    string fileExtension1 = Path.GetExtension(UploadImage.FileName);
                    if (!string.IsNullOrEmpty(fileName1) && this.IsImageFile(fileExtension1))
                    {
                        string imageNameOnServer = Guid.NewGuid().ToString() + fileExtension1;
                        string uploadImageAbsFilePath1 = Path.Combine(sDir, imageNameOnServer);
                        UploadImage.SaveAs(uploadImageAbsFilePath1);
                        string imageUrl = this.GetBasePathFromConfig() + "/" + imageNameOnServer;
                        /// Moved actual insertion out of this function. Now we only prepare necessary data here
                        ///this.InsertImageAndCarImageIntoDb(id, fileName1, imageUrl, uploadImageAbsFilePath1);
                        ret = new ImageInsertIntoDbInfo(id, fileName1, imageUrl, uploadImageAbsFilePath1);
                    }
                }
            }
            return ret;
        }

        public void InsertUploadImages(Guid id, HttpFileCollectionBase requestFiles, HttpServerUtilityBase Server, ImageCategory imageCategory)
        {
            for (int ind = 1; ind <= 2; ++ind)
            {
                string imageUploadNameIndex = "UploadImage" + ind.ToString();
                ImageInsertIntoDbInfo imgInfo = PrepareImageDbInfo(id, requestFiles, Server, imageUploadNameIndex);
                if (imgInfo != null) // if image was not chosen
                {
                    switch (imageCategory)
                    {
                        case ImageCategory.carImage:
                            InsertImageAndCarImageIntoDb(imgInfo);
                            break;
                        case ImageCategory.businessImage:
                            InsertImageAndBusinessImageIntoDb(imgInfo);
                            break;
                        case ImageCategory.listingImage:
                            InsertImageAndListingImageIntoDb(imgInfo);
                            break;
                        case ImageCategory.propertyImage:
                            InsertImageAndPropertyImageIntoDb(imgInfo);
                            break;
                        default:
                            Debug.Assert(false, "Unknown catogory for image");
                            break;
                    }
                }
            }
        }

        //
        // for Edit pages (upload and insert image right away?)
        public void InsertImageAndCarImageIntoDb(ImageInsertIntoDbInfo imgInfo)
        {
            ImageVo imgVo = new ImageVo();
            imgVo.name = imgInfo.fileName; // use file name as image name field in database
            imgVo.path = imgInfo.uploadImageAbsFilePath;
            imgVo.url = imgInfo.imgUrl;
            using (var db = new MainDb())
            {
                //todo: need to use the other way LINQ ??
                db.images.Add(imgVo);

                CarImagesVo carImageVo = new CarImagesVo();
                carImageVo.carId = imgInfo.id;
                carImageVo.imageId = imgVo.imageId;
                db.carImages.Add(carImageVo);

                db.SaveChanges();
            }
        }

        //
        public void InsertImageAndBusinessImageIntoDb(ImageInsertIntoDbInfo imgInfo)
        {
            ImageVo imgVo = new ImageVo();
            imgVo.name = imgInfo.fileName; // use file name as image name field in database
            imgVo.path = imgInfo.uploadImageAbsFilePath;
            imgVo.url = imgInfo.imgUrl;
            using (var db = new MainDb())
            {
                //todo: need to use the other way LINQ ??
                db.images.Add(imgVo);

                BusinessImagesVo businessImageVo = new BusinessImagesVo();
                businessImageVo.businessId = imgInfo.id;
                businessImageVo.imageId = imgVo.imageId;
                db.businessImages.Add(businessImageVo);

                db.SaveChanges();
            }
        }

        //
        // for Edit pages (upload and insert image right away)
        public void InsertImageAndListingImageIntoDb(ImageInsertIntoDbInfo imgInfo)
        {
            ImageVo imgVo = new ImageVo();
            imgVo.name = imgInfo.fileName; // use file name as image name field in database
            imgVo.path = imgInfo.uploadImageAbsFilePath;
            imgVo.url = imgInfo.imgUrl;
            using (var db = new MainDb())
            {
                //todo: need to use the other way LINQ ??
                db.images.Add(imgVo);

                ListingImagesVo listingImageVo = new ListingImagesVo();
                listingImageVo.listingId = imgInfo.id;
                listingImageVo.imageId = imgVo.imageId;
                db.listingImages.Add(listingImageVo);

                db.SaveChanges();
            }
        }

        //
        // for Edit pages (upload and insert image right away)
        public void InsertImageAndPropertyImageIntoDb(ImageInsertIntoDbInfo imgInfo)
        {
            ImageVo imgVo = new ImageVo();
            imgVo.name = imgInfo.fileName; // use file name as image name field in database
            imgVo.path = imgInfo.uploadImageAbsFilePath;
            imgVo.url = imgInfo.imgUrl;
            using (var db = new MainDb())
            {
                //todo: need to use the other way LINQ ??
                db.images.Add(imgVo);

                PropertyImageVo propertyImageVo = new PropertyImageVo();
                propertyImageVo.propertyId = imgInfo.id;
                propertyImageVo.imageId = imgVo.imageId;
                db.propertyImages.Add(propertyImageVo);

                db.SaveChanges();
            }
        }
        
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
            string sRet = "/Uploads/Images"; // default value if no configuration value exists
            string sVal = System.Configuration.ConfigurationManager.AppSettings.Get("UserImagesFolder");
            if (!String.IsNullOrEmpty(sVal))
            {
                if (sVal[0] != '/')
                    sVal = '/' + sVal;
                sRet = sVal;
            }
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

        public void RemoveImages(Guid id, List<ImageCheckBoxInfo> imagesToRemove, ImageCategory imgCategory)
        {
            // removing unchecked images
            if (imagesToRemove != null)
            {
                for (int ind = 0; ind < imagesToRemove.Count(); ind++)
                {
                    bool imgChecked = imagesToRemove[ind].imageIsChecked;
                    if (!imgChecked)
                    {
                        string strGuid = imagesToRemove[ind].imageIdStr;
                        Guid imgGuid = Guid.Empty;
                        if (Guid.TryParse(strGuid, out imgGuid))
                        {
                            this.RemoveImageFromDiskAndDb(/*id,*/ imgGuid);
                        }
                    }
                }
            }
        }

        public void RemoveImageFromDiskAndDb(/*Guid carId,*/ Guid imgGuid)
        {
            using (var db = new MainDb())
            {
                var query = db.images
                   .Where(m => m.imageId == imgGuid);

                // Delete the file from the disk
                var list = query.ToList();
                Debug.Assert(list.Count == 1);
                string imagePath = list[0].path;
                if (!String.IsNullOrEmpty(imagePath))
                {
                    try
                    {
                        File.Delete(imagePath);
                    }
                    catch (DirectoryNotFoundException dirNotFound)
                    {
                        Console.WriteLine(dirNotFound.Message);
                    }
                }
                // Delete image from Db
                query.Delete();
            }
        }

        // create list with check box info for Edit View (the list is stored in CarVm, BusinessVm ...
        public List<ImageCheckBoxInfo> CreateOrAddToImageList(List<ImageVo> carImages, bool isChecked = true)
        {
            List<ImageCheckBoxInfo> imagesToRemove = new List<ImageCheckBoxInfo>();
            foreach (ImageVo image in carImages)
            {

                ImageCheckBoxInfo carImgInfo = new ImageCheckBoxInfo(image.imageId.ToString(), image.url);
                imagesToRemove.Add(carImgInfo);
            }
            return imagesToRemove;
        }
    }
}

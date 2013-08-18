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
    public class BusinessImageManager : IBusinessImagesManager
    {
        public BusinessImageManager() { }

        public BusinessImagesVo get(Guid businessImageId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessImages
                            .Include(s => s.image)
                            .Include(t => t.business)
                            .FirstOrDefault(p => p.businessImageId == businessImageId);

                return res;
            }
        }

        public List<BusinessImagesVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.businessImages
                             .Include(s => s.image)
                             .Include(t => t.business)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(Guid businessImageId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessImages
                     .Where(e => e.businessImageId == businessImageId)
                     .Delete();
                return true;
            }
        }

        public BusinessImagesVo update(BusinessImagesVo input, Guid? businessImageId = null)
        {
            using (var db = new MainDb())
            {

                if (businessImageId  == null)
                    businessImageId = input.businessImageId;

                var res = db.businessImages.FirstOrDefault(e => e.businessImageId == businessImageId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public BusinessImagesVo insert(BusinessImagesVo input)
        {
            using (var db = new MainDb())
            {

                db.businessImages.Add(input);
                db.SaveChanges();

                return input;
            }
        }
        public int count()
        {
            using (var db = new MainDb())
            {
                return db.businessImages.Count();
            }
        }
    }
}

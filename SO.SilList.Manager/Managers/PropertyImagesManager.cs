using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;

namespace SO.SilList.Manager.Managers
{
    public class PropertyImagesManager : IPropertyImagesManager
    {
        public PropertyImageVo get(Guid rentalImageId)
        {
            using (var db = new MainDb())
            {
                var res = db.propertyImages
                            //.Include(s => s.image)
                            .FirstOrDefault(p => p.propertyImageId == rentalImageId);

                return res;
            }
        }

        public List<PropertyImageVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.propertyImages
                             //.Include(s => s.site)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(Guid rentalImageId)
        {
            using (var db = new MainDb())
            {
                var res = db.propertyImages
                     .Where(e => e.propertyImageId == rentalImageId)
                     .Delete();
                return true;
            }
        }

        public PropertyImageVo update(PropertyImageVo input, Guid? rentalImageId = null)
        {
            using (var db = new MainDb())
            {

                if (rentalImageId == null)
                    rentalImageId = input.propertyImageId;

                var res = db.propertyImages.FirstOrDefault(e => e.propertyImageId == rentalImageId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public PropertyImageVo insert(PropertyImageVo input)
        {
            using (var db = new MainDb())
            {

                db.propertyImages.Add(input);
                db.SaveChanges();

                return input;
            }
        }
    }
}

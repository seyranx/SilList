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
    class RentalImagesManager : IRentalImagesManager
    {

        public RentalImagesManager()
        {

        }

        public RentalImageVo get(Guid rentalImageId)
        {
            using (var db = new MainDb())
            {
                var res = db.rentalImages
                            //.Include(s => s.image)
                            .FirstOrDefault(p => p.rentalImageId == rentalImageId);

                return res;
            }
        }

        public List<RentalImageVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.rentalImages
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
                var res = db.rentalImages
                     .Where(e => e.rentalImageId == rentalImageId)
                     .Delete();
                return true;
            }
        }

        public RentalImageVo update(RentalImageVo input, Guid? rentalImageId = null)
        {
            using (var db = new MainDb())
            {

                if (rentalImageId == null)
                    rentalImageId = input.rentalImageId;

                var res = db.rentalImages.FirstOrDefault(e => e.rentalImageId == rentalImageId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public RentalImageVo insert(RentalImageVo input)
        {
            using (var db = new MainDb())
            {

                db.rentalImages.Add(input);
                db.SaveChanges();

                return input;
            }
        }
    }
}

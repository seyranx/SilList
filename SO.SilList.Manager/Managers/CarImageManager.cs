using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Managers
{
    public class CarImageManager: ICarImageManager
    {

        public CarImageVo get(Guid carImageId)
        {
            using (var db = new MainDb())
            {
                var result = db.carImage
                            .FirstOrDefault(r => r.carImageId == carImageId);

                return result;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public CarImageVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.carImage
                            .FirstOrDefault();

                return res;
            }
        }

        public List<CarImageVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.carImage
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(Guid carImageId)
        {
            using (var db = new MainDb())
            {
                var res = db.carImage
                     .Where(e => e.carImageId == carImageId)
                     .Delete();
                return true;
            }
        }

        public CarImageVo update(CarImageVo input, Guid? carImageId = null)
        {
            using (var db = new MainDb())
            {

                if (carImageId == null)
                    carImageId = input.carImageId;

                var res = db.carImage.FirstOrDefault(e => e.carId == carImageId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public CarImageVo insert(CarImageVo input)
        {
            using (var db = new MainDb())
            {

                db.carImage.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.carImage.Count();
            }
        }
    }
}

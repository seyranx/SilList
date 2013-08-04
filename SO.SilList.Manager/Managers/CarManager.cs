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
    public class CarManager : ICarManager
    {

        public CarVo get(Guid carId)
        {
            using (var db = new MainDb())
            {
                var result = db.car
                            .FirstOrDefault(r => r.carId == carId);

                return result;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public CarVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.car
                            .FirstOrDefault();

                return res;
            }
        }

        public List<CarVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.car
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(Guid carId)
        {
            using (var db = new MainDb())
            {
                var res = db.car
                     .Where(e => e.carId == carId)
                     .Delete();
                return true;
            }
        }

        public CarVo update(CarVo input, Guid? carId = null)
        {
            using (var db = new MainDb())
            {

                if (carId == null)
                    carId = input.carId;

                var res = db.car.FirstOrDefault(e => e.carId == carId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public CarVo insert(CarVo input)
        {
            using (var db = new MainDb())
            {

                db.car.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.car.Count();
            }
        }
    }
}

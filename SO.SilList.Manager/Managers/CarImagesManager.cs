using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Manager.Managers
{
    public class CarImagesManager: ICarImagesManager
    {
        public CarImagesManager()
        { }

        public CarImagesVo get(Guid carImagesId)
        {
            using (var db = new MainDb())
            {
                var result = db.carImages
                            .Include(c => c.car)
                            .Include(b => b.car.modelType)
                            .Include(d => d.car.modelType.makeType)
                            .Include(i => i.image)
                            .FirstOrDefault(r => r.carImagesId == carImagesId);

                return result;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public CarImagesVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.carImages
                            .Include(c => c.car)
                            .Include(i => i.image)
                            .FirstOrDefault();

                return res;
            }
        }

        public List<CarImagesVo> search(CarImagesVm input)
        {

            using (var db = new MainDb())
            {
                var list = db.carImages
                        .Include(c => c.car)
                            .Include(i => i.image)
                             .OrderBy(b => b.carId)
                             .Skip(input.skip)
                             .Take(input.rowCount)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.carId.Equals(int.Parse(input.keyword)) || string.IsNullOrEmpty(input.keyword))
                                    )
                             .ToList();

                return list;
            }
        }

        public List<CarImagesVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.carImages
                            .Include(c => c.car)
                            .Include(b => b.car.modelType)
                            .Include(d => d.car.modelType.makeType)
                            .Include(i => i.image)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(Guid carImagesId)
        {
            using (var db = new MainDb())
            {
                var res = db.carImages
                     .Where(e => e.carImagesId == carImagesId)
                     .Delete();
                return true;
            }
        }

        public CarImagesVo update(CarImagesVo input, Guid? carImagesId = null)
        {
            using (var db = new MainDb())
            {

                if (carImagesId == null)
                    carImagesId = input.carImagesId;

                var res = db.carImages.FirstOrDefault(e => e.carId == carImagesId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public CarImagesVo insert(CarImagesVo input)
        {
            using (var db = new MainDb())
            {

                db.carImages.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.carImages.Count();
            }
        }
    }
}

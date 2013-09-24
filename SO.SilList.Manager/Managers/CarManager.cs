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
    public class CarManager : ICarManager
    {

            public CarManager()
        {

        }

        public CarVo get(Guid carId)
        {
            using (var db = new MainDb())
            {
                var result = db.car
                            .Include(s => s.site)
                            .Include(m => m.modelType)
                            .Include(m => m.modelType.makeType)
                            .Include(b => b.carBodyType)
                            .Include(t => t.transmissionType)
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
                          .Include(s => s.site)
                            .Include(m => m.modelType)
                            .Include(b => b.carBodyType)
                            .Include(t => t.transmissionType)
                            .FirstOrDefault();

                return res;
            }
        }

        public CarVm search(CarVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.car
                            .Include(s => s.site)
                            .Include(m => m.modelType)
                            .Include(m => m.modelType.makeType)
                            .Include(b => b.carBodyType)
                            .Include(t => t.transmissionType)
                            .OrderBy(b => b.modelType.name)
                            .Where(e => (input.car.isActive == null || e.isActive == input.isActive)
                                      && (e.modelType.name.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                             );
                input.totalCount = query.Count();
                input.result = query         
                             .Skip(input.skip)
                             .Take(input.rowCount)

                             .ToList();

                return input;
            }
        }

        public List<CarVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.car
                          .Include(s => s.site)
                            .Include(m => m.modelType)
                            .Include(m=>m.modelType.makeType)
                            .Include(b => b.carBodyType)
                            .Include(t => t.transmissionType)
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

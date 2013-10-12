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
    public class CarEngineTypeManager : ICarEngineTypeManager
    {
        CarEngineTypeManager()
        {

        }

        public CarEngineTypeVo get(int carEngineTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.carEngineType

                            .Include(c => c.car)

                            .FirstOrDefault(r => r.carEngineTypeId == carEngineTypeId);

                return result;
            }
        }

        public List<CarEngineTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.carEngineType
                            .Include(c => c.car)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();
                

                return list;
            }
        }

        public CarEngineTypeVm search(CarEngineTypeVm input)
        {
             using (var db = new MainDb())
            {
                var query = db.carEngineType
                            .Include(c => c.car)
                            .OrderBy(b => b.name)
                            .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.name.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                             );
                input.paging.totalCount = query.Count();
                input.result = query         
                             .Skip(input.paging.skip)
                             .Take(input.paging.rowCount)

                             .ToList();

                return input;
            }
        }

        public CarEngineTypeVo update(CarEngineTypeVo input, int? carEngineTypeId = null)
        {
                        using (var db = new MainDb())
            {

                if (carEngineTypeId == null)
                    carEngineTypeId = input.carEngineTypeId;

                var res = db.carEngineType.FirstOrDefault(e => e.carEngineTypeId == carEngineTypeId);

                if (res == null) return null;
                
                input.created = res.created;
                input.createdBy = res.createdBy;
               
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public CarEngineTypeVo insert(CarEngineTypeVo input)
        {
                    using (var db = new MainDb())
            {

                db.carEngineType.Add(input);
                db.SaveChanges();

                return input;
            }
        }




        public bool delete(int carEngineTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.carEngineType
                     .Where(e => e.carEngineTypeId == carEngineTypeId)
                     .Delete();
                return true;
            }
        }


   

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.carEngineType.Count();
            }
        }

    }
}

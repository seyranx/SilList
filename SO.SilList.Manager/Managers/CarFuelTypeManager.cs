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
    public class CarFuelTypeManager : ICarFuelTypeManager
    {
        CarFuelTypeManager()
        {

        }

        public CarFuelTypeVo get(int carFuelTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.carFuelType

                            .Include(c => c.car)

                            .FirstOrDefault(r => r.carFuelTypeId == carFuelTypeId);

                return result;
            }
        }

        public List<CarFuelTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.carFuelType
                            .Include(c => c.car)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();
                

                return list;
            }
        }

        public CarFuelTypeVm search(CarFuelTypeVm input)
        {
             using (var db = new MainDb())
            {
                var query = db.carFuelType
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

        public CarFuelTypeVo update(CarFuelTypeVo input, int? carFuelTypeId = null)
        {
                        using (var db = new MainDb())
            {

                if (carFuelTypeId == null)
                    carFuelTypeId = input.carFuelTypeId;

                var res = db.carFuelType.FirstOrDefault(e => e.carFuelTypeId == carFuelTypeId);

                if (res == null) return null;
                
                input.created = res.created;
                input.createdBy = res.createdBy;
               
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public CarFuelTypeVo insert(CarFuelTypeVo input)
        {
                    using (var db = new MainDb())
            {

                db.carFuelType.Add(input);
                db.SaveChanges();

                return input;
            }
        }




        public bool delete(int carFuelTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.carFuelType
                     .Where(e => e.carFuelTypeId == carFuelTypeId)
                     .Delete();
                return true;
            }
        }


   

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.carFuelType.Count();
            }
        }

    }
}

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
    public class CarDriveTypeManager : ICarDriveTypeManager
    {
        CarDriveTypeManager()
        {

        }

        public CarDriveTypeVo get(int carDriveTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.carDriveType

                            .Include(c => c.car)

                            .FirstOrDefault(r => r.carDriveTypeId == carDriveTypeId);

                return result;
            }
        }

        public List<CarDriveTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.carDriveType
                            .Include(c => c.car)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();
                

                return list;
            }
        }

        public CarDriveTypeVm search(CarDriveTypeVm input)
        {
             using (var db = new MainDb())
            {
                var query = db.carDriveType
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

        public CarDriveTypeVo update(CarDriveTypeVo input, int? carDriveTypeId = null)
        {
                        using (var db = new MainDb())
            {

                if (carDriveTypeId == null)
                    carDriveTypeId = input.carDriveTypeId;

                var res = db.carDriveType.FirstOrDefault(e => e.carDriveTypeId == carDriveTypeId);

                if (res == null) return null;
                
                input.created = res.created;
                input.createdBy = res.createdBy;
               
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public CarDriveTypeVo insert(CarDriveTypeVo input)
        {
                    using (var db = new MainDb())
            {

                db.carDriveType.Add(input);
                db.SaveChanges();

                return input;
            }
        }




        public bool delete(int carDriveTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.carDriveType
                     .Where(e => e.carDriveTypeId == carDriveTypeId)
                     .Delete();
                return true;
            }
        }


   

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.carDriveType.Count();
            }
        }

    }
}

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
    public class CarDoorTypeManager : ICarDoorTypeManager
    {
        public CarDoorTypeManager()
        {

        }

        public CarDoorTypeVo get(int carDoorTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.carDoorType

                            

                            .FirstOrDefault(r => r.carDoorTypeId == carDoorTypeId);

                return result;
            }
        }

        public List<CarDoorTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.carDoorType
                            .OrderBy(n => n.name)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();
                

                return list;
            }
        }

        public CarDoorTypeVm search(CarDoorTypeVm input)
        {
             using (var db = new MainDb())
            {
                var query = db.carDoorType
                            
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

        public CarDoorTypeVo update(CarDoorTypeVo input, int? carDoorTypeId = null)
        {
                        using (var db = new MainDb())
            {

                if (carDoorTypeId == null)
                    carDoorTypeId = input.carDoorTypeId;

                var res = db.carDoorType.FirstOrDefault(e => e.carDoorTypeId == carDoorTypeId);

                if (res == null) return null;
                
                input.created = res.created;
                input.createdBy = res.createdBy;
               
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public CarDoorTypeVo insert(CarDoorTypeVo input)
        {
                    using (var db = new MainDb())
            {

                db.carDoorType.Add(input);
                db.SaveChanges();

                return input;
            }
        }




        public bool delete(int carDoorTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.carDoorType
                     .Where(e => e.carDoorTypeId == carDoorTypeId)
                     .Delete();
                return true;
            }
        }


   

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.carDoorType.Count();
            }
        }

    }
}

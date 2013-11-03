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
    public class CarColorTypeManager : ICarColorTypeManager
    {
        public CarColorTypeManager()
        {

        }

        public CarColorTypeVo get(int carColorTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.carColorType

                            //.Include(c => c.car)

                            .FirstOrDefault(r => r.carColorTypeId == carColorTypeId);

                return result;
            }
        }

        public List<CarColorTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.carColorType
                          //  .Include(c => c.car)
                            .OrderBy(n => n.name)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();
                

                return list;
            }
        }

        public CarColorTypeVm search(CarColorTypeVm input)
        {
             using (var db = new MainDb())
            {
                var query = db.carColorType
                           // .Include(c => c.car)
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

        public CarColorTypeVo update(CarColorTypeVo input, int? carColorTypeId = null)
        {
                        using (var db = new MainDb())
            {

                if (carColorTypeId == null)
                    carColorTypeId = input.carColorTypeId;

                var res = db.carColorType.FirstOrDefault(e => e.carColorTypeId == carColorTypeId);

                if (res == null) return null;
                
                input.created = res.created;
                input.createdBy = res.createdBy;
               
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public CarColorTypeVo insert(CarColorTypeVo input)
        {
                    using (var db = new MainDb())
            {

                db.carColorType.Add(input);
                db.SaveChanges();

                return input;
            }
        }


        

        public bool delete(int carColorTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.carColorType
                     .Where(e => e.carColorTypeId == carColorTypeId)
                     .Delete();
                return true;
            }
        }


   

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.cityType.Count();
            }
        }


    }
}

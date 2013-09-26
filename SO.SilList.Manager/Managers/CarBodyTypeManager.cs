using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Manager.Managers
{
    public class CarBodyTypeManager: ICarBodyTypeManager
    {
        public CarBodyTypeManager()
        {}

        public CarBodyTypeVo get(int carBodyTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.carBodyType
                            .FirstOrDefault(r => r.carBodyTypeId == carBodyTypeId);

                return result;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public CarBodyTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.carBodyType
                            .FirstOrDefault();

                return res;
            }
        }

        public CarBodyTypeVm search(CarBodyTypeVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.carBodyType
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

        public List<CarBodyTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.carBodyType
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(int carBodyTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.carBodyType
                     .Where(e => e.carBodyTypeId == carBodyTypeId)
                     .Delete();
                return true;
            }
        }

        public CarBodyTypeVo update(CarBodyTypeVo input, int? carBodyTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (carBodyTypeId == null)
                    carBodyTypeId = input.carBodyTypeId;

                var res = db.carBodyType.FirstOrDefault(e => e.carBodyTypeId == carBodyTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public CarBodyTypeVo insert(CarBodyTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.carBodyType.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.carBodyType.Count();
            }
        }
    }
}

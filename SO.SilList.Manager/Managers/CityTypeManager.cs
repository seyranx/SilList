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
    public class CityTypeManager : ICityTypeManager
    {
        public CityTypeManager()
        {

        }

        public CityTypeVo get(int cityTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.cityType
                             .Include(c => c.countryType)
                            .Include(s => s.stateType)

                            .FirstOrDefault(r => r.cityTypeId == cityTypeId);

                return result;
            }
        }


        public List<CityTypeVo> search(string keyword)
        {
            using (var db = new MainDb())
            {
                var query = (from c in db.cityType.Include(s=>s.stateType).Include(b=>b.countryType)
                             // join s in db.stateType on c.cityTypeId equals s.stateTypeId
                             where c.name.StartsWith(keyword)
                             select c
                            );


                return query.ToList();
            }
        }

        public CityTypeVm search(CityTypeVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.cityType
                            .Include(c => c.countryType)
                            .Include(s => s.stateType)
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

        public List<CityTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.cityType
                                                .Include(c => c.countryType)
                            .Include(s => s.stateType)
.OrderBy(n => n.name)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();


                return list;
            }
        }

        public bool delete(int cityTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.cityType
                     .Where(e => e.cityTypeId == cityTypeId)
                     .Delete();
                return true;
            }
        }

        public CityTypeVo update(CityTypeVo input, int? cityTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (cityTypeId == null)
                    cityTypeId = input.cityTypeId;

                var res = db.cityType.FirstOrDefault(e => e.cityTypeId == cityTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;

                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public CityTypeVo insert(CityTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.cityType.Add(input);
                db.SaveChanges();

                return input;
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

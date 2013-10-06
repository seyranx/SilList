using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ViewModels;


namespace SO.SilList.Manager.Managers
{
    public class RentTypeManager : IRentTypeManager
    {
        public RentTypeVo get(int rentTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.rentTypes
                    //.Include(s => s.image)
                            .FirstOrDefault(p => p.rentTypeId == rentTypeId);

                return res;
            }
        }

        public RentTypeVm search(RentTypeVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.rentTypes
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

        public List<RentTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.rentTypes
                             //.Include(s => s.site)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(int rentTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.rentTypes
                     .Where(e => e.rentTypeId == rentTypeId)
                     .Delete();
                return true;
            }
        }

        public RentTypeVo update(RentTypeVo input, int? rentTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (rentTypeId == null)
                    rentTypeId = input.rentTypeId;

                var res = db.rentTypes.FirstOrDefault(e => e.rentTypeId == rentTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public RentTypeVo insert(RentTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.rentTypes.Add(input);
                db.SaveChanges();

                return input;
            }
        }
    }
}

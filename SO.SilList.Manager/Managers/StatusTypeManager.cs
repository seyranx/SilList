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
    public class StatusTypeManager : IStatusTypeManager
    {
        public StatusTypeVo get(int rentTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.statusTypes
                    //.Include(s => s.image)
                            .FirstOrDefault(p => p.statusTypeId == rentTypeId);

                return res;
            }
        }

        public StatusTypeVm search(StatusTypeVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.statusTypes
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

        public List<StatusTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.statusTypes
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
                var res = db.statusTypes
                     .Where(e => e.statusTypeId == rentTypeId)
                     .Delete();
                return true;
            }
        }

        public StatusTypeVo update(StatusTypeVo input, int? rentTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (rentTypeId == null)
                    rentTypeId = input.statusTypeId;

                var res = db.statusTypes.FirstOrDefault(e => e.statusTypeId == rentTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public StatusTypeVo insert(StatusTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.statusTypes.Add(input);
                db.SaveChanges();

                return input;
            }
        }
    }
}

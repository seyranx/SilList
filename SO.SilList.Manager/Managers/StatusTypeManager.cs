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
    public class StatusTypeManager : IEntryStatusTypeManager
    {
        public EntryStatusTypeVo get(int rentTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.entryStatusType
                    //.Include(s => s.image)
                            .FirstOrDefault(p => p.entryStatusTypeId == rentTypeId);

                return res;
            }
        }

        public EntryStatusTypeVm search(EntryStatusTypeVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.entryStatusType
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

        public List<EntryStatusTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.entryStatusType
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
                var res = db.entryStatusType
                     .Where(e => e.entryStatusTypeId == rentTypeId)
                     .Delete();
                return true;
            }
        }

        public EntryStatusTypeVo update(EntryStatusTypeVo input, int? rentTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (rentTypeId == null)
                    rentTypeId = input.entryStatusTypeId;

                var res = db.entryStatusType.FirstOrDefault(e => e.entryStatusTypeId == rentTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public EntryStatusTypeVo insert(EntryStatusTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.entryStatusType.Add(input);
                db.SaveChanges();

                return input;
            }
        }
    }
}

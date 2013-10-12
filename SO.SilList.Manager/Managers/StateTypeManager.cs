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
    public class StateTypeManager : IStateTypeManager
    {
        StateTypeManager()
        {

        }

        public StateTypeVo get(int stateTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.stateType

                            .Include(c => c.car)
                            .Include(j => j.job)
                            .Include(m => m.member)
                            .Include(b => b.business)
                            .Include(l => l.listing)
                            .Include(r => r.rental)

                            .FirstOrDefault(r => r.stateTypeId == stateTypeId);

                return result;
            }
        }


        public StateTypeVm search(StateTypeVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.stateType
                            .Include(c => c.car)
                            .Include(j => j.job)
                            .Include(m => m.member)
                            .Include(b => b.business)
                            .Include(l => l.listing)
                            .Include(r => r.rental)
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

        public List<StateTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.stateType
                            .Include(c => c.car)
                            .Include(j => j.job)
                            .Include(m => m.member)
                            .Include(b => b.business)
                            .Include(l => l.listing)
                            .Include(r => r.rental)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();
                

                return list;
            }
        }

        public bool delete(int stateTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.stateType
                     .Where(e => e.stateTypeId == stateTypeId)
                     .Delete();
                return true;
            }
        }

        public StateTypeVo update(StateTypeVo input, int? stateTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (stateTypeId == null)
                    stateTypeId = input.stateTypeId;

                var res = db.stateType.FirstOrDefault(e => e.stateTypeId == stateTypeId);

                if (res == null) return null;
                
                input.created = res.created;
                input.createdBy = res.createdBy;
               
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public StateTypeVo insert(StateTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.stateType.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.stateType.Count();
            }
        }
    }
}

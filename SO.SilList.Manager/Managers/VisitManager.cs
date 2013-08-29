using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;

namespace SO.SilList.Manager.Managers
{
    public class VisitManager : IVisitManager

    {
        public List<Models.ValueObjects.VisitVo> search(Models.ViewModels.VisitVm input)
        {
            using (var db = new MainDb())
            {
                var list = db.visits                             
                             .Where(e => (
                                 string.IsNullOrEmpty(input.keyword) ||
                                 e.action.Contains(input.keyword) ||
                                 e.controller.Contains(input.keyword) ||
                                 e.referrerUrl.Contains(input.keyword) ||
                                 e.ipAddress.Contains(input.keyword)
                                         )
                                    )
                             .OrderBy(b => b.visitTime)
                             .Skip(input.skip)
                             .Take(input.rowsPerPage)
                             .ToList();

                return list;
            }
        }

        public Models.ValueObjects.VisitVo insert(Models.ValueObjects.VisitVo input)
        {
            using (var db = new MainDb())
            {
                db.visits.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int delete(DateTime input)
        {
            using (var db = new MainDb())
            {
                var res = db.visits
                     .Where(e => e.visitTime < input)
                     .Delete();

                                return 0;
            }
        }
    }
}

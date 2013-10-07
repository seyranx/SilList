using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;


namespace SO.SilList.Manager.Managers
{
    public class VisitManager : IVisitManager

    {
        public VisitVm search(VisitVm input)
        {
            using (var db = new MainDb())
            {
                IQueryable<VisitVo> q = db.visits
                             .Include(s => s.site)
                             .Where(e => (
                                 (
                                    null == input.siteId || e.siteId == input.siteId
                                 ) &&
                                 (
                                    string.IsNullOrEmpty(input.keyword) ||
                                    e.action.Contains(input.keyword) ||
                                    e.controller.Contains(input.keyword) ||
                                    e.referrerUrl.Contains(input.keyword) ||
                                    e.ipAddress.Contains(input.keyword)
                                 )
                                    ));
                input.totalRows = q.Count();
                
                input.result = q
                    .OrderBy(b => b.visitCount)
                    .ThenBy(c => c.modified)
                   // .Skip(input.skip)
                  //  .Take(input.rowsPerPage)
                    .ToList();

                return input;
            }
        }

        public Models.ValueObjects.VisitVo insertOrUpdate(VisitVo input)
        {
            using (var db = new MainDb())
            {
                DateTime d = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));

                IQueryable<VisitVo> q = db.visits.Where(e =>
                                        e.siteId == input.siteId &&
                                        e.ipAddress == input.ipAddress &&
                                        e.controller == input.controller &&
                                        e.action == input.action &&
                                        e.created > d);
                /*if (q.Count() == 0)
                {
                    db.visits.Add(input);
                }
                else
                {
                    VisitVo visit = q.First();
                    visit.visitCount++;
                    db.Entry(visit).CurrentValues.SetValues(visit);
                }*/
                
                db.SaveChanges();

                return input;
            }
        }

        public int delete(DateTime input)
        {
            using (var db = new MainDb())
            {
                var res = db.visits
                     .Where(e => e.modified < input)
                     .Delete();

                return 0;
            }
        }
    }
}

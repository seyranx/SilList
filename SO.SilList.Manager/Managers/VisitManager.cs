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
        public int count(VisitVm input)
        {
            using (var db = new MainDb())
            {
                return db.visits
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
                                    ))
                             .Count();
            }
        }

        public List<VisitVo> search(VisitVm input)
        {
            using (var db = new MainDb())
            {
                var list = db.visits
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
                                    ))
                             .OrderBy(b => b.visitCount)
                             .ThenBy(c => c.modified)
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
                     .Where(e => e.modified < input)
                     .Delete();

                return 0;
            }
        }
    }
}

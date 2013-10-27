using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Manager.Managers
{
    public class ApproveEntriesManager
    {
        //TODO: implement first for Jobs . .. later add other componens that are subject to Approval
        public ApproveEntriesVm search(ApproveEntriesVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.jobs
                            // .Include(s => s.site)
                            // .Include(j => j.jobType)
                            // .Include(t => t.jobCompany)
                            //.Include(i => i.cityType)
                            //.Include(o => o.countryType)
                            //.Include(u => u.stateType) 

                            .OrderBy(b => b.title)
                            .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.title.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                             );
                input.paging.totalCount = query.Count();
                input.result = query
                             .Skip(input.paging.skip)
                             .Take(input.paging.rowCount)

                             .ToList();

                return input;
            }
        }
        public JobVo insert(JobVo input)
        {
            using (var db = new MainDb())
            {
                db.jobs.Add(input);
                db.SaveChanges();

                return input;
            }
        }
    }
}

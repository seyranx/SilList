using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Managers
{
    public class SiteManager : ISiteManager
    {
        public SiteVo get(int siteId)
        {
            using (var db = new MainDb())
            {
                var result = db.sites
                            .FirstOrDefault(s => s.siteId == siteId);
                return result;
            }
        }

        public List<SiteVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.sites
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(int siteId)
        {
           using(var db = new MainDb())
           {
        //TODO: Site deletion will be somewhat complicated if the site with given id references already by other tables  . ..
              //var res = db.sites
              //   .Where(e => e.siteId == siteId)
              //   .Delete();
              return true;
           }
        }

        public SiteVo update(SiteVo input, int? siteId = null)
        {
           using (var db = new MainDb())
           {
              if(siteId == null)
               siteId = input.siteId;

              var res  = db.sites.FirstOrDefault(e => e.siteId == siteId);

              if (res == null) return null;
              
              input.created = res.created;
              input.createdBy = res.createdBy;
              db.Entry(res).CurrentValues.SetValues(input);

              db.SaveChanges();
              return res;
           }
        }

        public SiteVo insert(SiteVo input)
        {
           using (var db = new MainDb())
           {
               db.sites.Add(input);
               db.SaveChanges();

               return input;
           }
        }
    }
}

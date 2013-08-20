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

        //TODO: Site deletion will be somewhat complicated if the site with given id references already by other tables  . ..
        public bool delete(int siteId)
        {
            throw new NotImplementedException();
        }

        public SiteVo update(SiteVo input, int? siteId = null)
        {
            throw new NotImplementedException();
        }

        public SiteVo insert(SiteVo input)
        {
            throw new NotImplementedException();
        }
    }
}

using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ISiteManager
    {

         SiteVo get(int siteId);
         List<SiteVo> getAll(bool? isActive = true);
         bool delete(int siteId);
         SiteVo update(SiteVo input, int? siteId = null);
         SiteVo insert(SiteVo input);
    }
}

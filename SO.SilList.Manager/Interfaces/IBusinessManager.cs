using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IBusinessManager
    {
         BusinessVo getByName(string name);
         BusinessVo get(Guid businessId);
         List<BusinessVo> getAll(bool? isActive=true);
         bool delete(Guid businessId);
         BusinessVo update(BusinessVo input, Guid? businessId = null);
         BusinessVo insert(BusinessVo input);
    }
}

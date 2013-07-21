using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IBusinessManager
    {

         BusinessVo findByName(string name);
         BusinessVo find(Guid businessId);
         List<BusinessVo> findAll(bool? isActive=true);
         bool delete(Guid businessId);
         BusinessVo update(BusinessVo input, Guid businessId = -1);
         BusinessVo insert(BusinessVo input);
    }
}

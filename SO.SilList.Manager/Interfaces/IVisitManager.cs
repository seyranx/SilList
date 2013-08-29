using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Interfaces
{
    interface IVisitManager
    {
        VisitVo get(Guid businessId);
        List<BusinessVo> getAll(bool? isActive = true);
        bool delete(Guid businessId);
        BusinessVo update(BusinessVo input, Guid? businessId = null);
        BusinessVo insert(BusinessVo input);
    }
}

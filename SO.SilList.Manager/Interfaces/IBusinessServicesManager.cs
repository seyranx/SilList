using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IBusinessServicesManager
    {
        BusinessServicesVo get(int serviceTypeId);
        List<BusinessServicesVo> getAll(bool? isActive = true);
        bool delete(int serviceTypeId);
        BusinessServicesVo update(BusinessServicesVo input, int? serviceTypeId = null);
        BusinessServicesVo insert(BusinessServicesVo input);
    }
}

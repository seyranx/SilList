
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IServiceTypeManager
    {
        ServiceTypeVo getByName(string name);
        ServiceTypeVo get(int serviceTypeId);
        List<ServiceTypeVo> getAll(bool? isActive = true);
        bool delete(int serviceTypeId);
        ServiceTypeVo update(ServiceTypeVo input, int? serviceTypeId = null);
        ServiceTypeVo insert(ServiceTypeVo input);
    }
}

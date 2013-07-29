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
        BusinessServicesVo get(Guid businessServiceId);
        List<BusinessServicesVo> getAll(bool? isActive = true);
        bool delete(Guid businessServiceId);
        BusinessServicesVo update(BusinessServicesVo input, Guid? businessServiceId = null);
        BusinessServicesVo insert(BusinessServicesVo input);
    }
}

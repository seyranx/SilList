using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IPropertyManager
    {
        PropertyVo get(Guid rentalId);
        List<PropertyVo> getAll(bool? isActive = true);
        bool delete(Guid rentalId);
        PropertyVo update(PropertyVo input, Guid? rentalId = null);
        PropertyVo insert(PropertyVo input);
    }
}

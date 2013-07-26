using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IPropertyTypeManager
    {
        PropertyTypeVo get(int propertyTypeId);
        List<PropertyTypeVo> getAll(bool? isActive = true);
        bool delete(int propertyTypeId);
        PropertyTypeVo update(PropertyTypeVo input, int? propertyTypeId = null);
        PropertyTypeVo insert(PropertyTypeVo input);
    }
}

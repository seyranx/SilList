using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Managers
{
    class PropertyTypeManager : IPropertyTypeManager
    {
        public PropertyTypeVo get(int propertyTypeId)
        {
            throw new NotImplementedException();
        }

        public List<PropertyTypeVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(int propertyTypeId)
        {
            throw new NotImplementedException();
        }

        public PropertyTypeVo update(PropertyTypeVo input, int? propertyTypeId = null)
        {
            throw new NotImplementedException();
        }

        public PropertyTypeVo insert(PropertyTypeVo input)
        {
            throw new NotImplementedException();
        }
    }
}

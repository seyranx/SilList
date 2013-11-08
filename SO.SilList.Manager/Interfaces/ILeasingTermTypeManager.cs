using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ILeasingTermTypeManager
    {

        PropertyListingTypeVo get(int leaseTermTypeId);
        List<PropertyListingTypeVo> getAll(bool? isActive = true);
        bool delete(int leaseTermTypeId);
        PropertyListingTypeVo update(PropertyListingTypeVo input, int? leaseTermTypeId = null);
         PropertyListingTypeVo insert(PropertyListingTypeVo input);
    }
}

using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IBusinessCategoryTypeManager
    {

        BusinessCategoryTypeVo get(int businessCategoryTypeId);
        List<BusinessCategoryTypeVo> getAll(bool? isActive = true);
        bool delete(int businessCategoryTypeId);
        BusinessCategoryTypeVo update(BusinessCategoryTypeVo input, int? businessCategoryTypeId = null);
         BusinessCategoryTypeVo insert(BusinessCategoryTypeVo input);
    }
}

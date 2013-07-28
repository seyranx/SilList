using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IBusinessCategoriesManager
    {
         BusinessCategoriesVo get(int businessCategoryTypeId);
         List<BusinessCategoriesVo> getAll(bool? isActive = true);
         bool delete(int businessCategoryTypeId);
         BusinessCategoriesVo update(BusinessCategoriesVo input, int? businessCategoryTypeId = null);
         BusinessCategoriesVo insert(BusinessCategoriesVo input);
    }
}

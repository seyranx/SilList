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
         BusinessCategoriesVo get(Guid businessCategoryTypeId);
         List<BusinessCategoriesVo> getAll(bool? isActive = true);
         bool delete(Guid businessCategoryTypeId);
         BusinessCategoriesVo update(BusinessCategoriesVo input, Guid? businessCategoryTypeId = null);
         BusinessCategoriesVo insert(BusinessCategoriesVo input);
    }
}

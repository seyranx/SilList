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
         BusinessCategoriesVo get(Guid businessCategoryId);
         List<BusinessCategoriesVo> getAll(bool? isActive = true);
         bool delete(Guid businessCategoryId);
         BusinessCategoriesVo update(BusinessCategoriesVo input, Guid? businessCategoryId = null);
         BusinessCategoriesVo insert(BusinessCategoriesVo input);
    }
}

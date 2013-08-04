using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IModelTypeManager
    {

         ModelTypeVo get(int modelTypeId);
         List<ModelTypeVo> getAll(bool? isActive = true);
         bool delete(int modelTypeId);
         ModelTypeVo update(ModelTypeVo input, int? modelTypeId = null);
         ModelTypeVo insert(ModelTypeVo input);
    }
}

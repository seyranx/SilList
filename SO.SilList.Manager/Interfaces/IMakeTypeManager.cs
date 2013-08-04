using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IMakeTypeManager
    {

         MakeTypeVo get(int makeTypeId);
         List<MakeTypeVo> getAll(bool? isActive = true);
         bool delete(int makeTypeId);
         MakeTypeVo update(MakeTypeVo input, int? makeTypeId = null);
         MakeTypeVo insert(MakeTypeVo input);
    }
}

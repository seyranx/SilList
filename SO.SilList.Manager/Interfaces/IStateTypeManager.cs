using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IStateTypeManager
    {

         StateTypeVo get(int stateTypeId);
         List<StateTypeVo> getAll(bool? isActive = true);
         StateTypeVm search(StateTypeVm input);
         bool delete(int stateTypeId);
         StateTypeVo update(StateTypeVo input, int? stateTypeId = null);
         StateTypeVo insert(StateTypeVo input);
    }
}

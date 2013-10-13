using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ICarEngineTypeManager
    {

        CarEngineTypeVo get(int carEngineTypeId);
        List<CarEngineTypeVo> getAll(bool? isActive = true);
        CarEngineTypeVm search(CarEngineTypeVm input);
        bool delete(int carEngineTypeId);
        CarEngineTypeVo update(CarEngineTypeVo input, int? carEngineTypeId = null);
         CarEngineTypeVo insert(CarEngineTypeVo input);
    }
}

using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ICarDoorTypeManager
    {

        CarDoorTypeVo get(int carDoorTypeId);
         List<CarDoorTypeVo> getAll(bool? isActive = true);
         CarDoorTypeVm search(CarDoorTypeVm input);
         bool delete(int carDoorTypeId);
         CarDoorTypeVo update(CarDoorTypeVo input, int? carDoorTypeId = null);
         CarDoorTypeVo insert(CarDoorTypeVo input);
    }
}

using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ICarDriveTypeManager
    {

        CarDriveTypeVo get(int carDriveTypeId);
        List<CarDriveTypeVo> getAll(bool? isActive = true);
        CarDriveTypeVm search(CarDriveTypeVm input);
        bool delete(int carDriveTypeId);
         CarDriveTypeVo update(CarDriveTypeVo input, int? carDriveTypeId = null);
         CarDriveTypeVo insert(CarDriveTypeVo input);
    }
}

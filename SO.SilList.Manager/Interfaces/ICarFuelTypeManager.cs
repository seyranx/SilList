using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ICarFuelTypeManager
    {

         CarFuelTypeVo get(int carFuelTypeId);
         List<CarFuelTypeVo> getAll(bool? isActive = true);
         CarFuelTypeVm search(CarFuelTypeVm input);
         bool delete(int carFuelTypeId);
         CarFuelTypeVo update(CarFuelTypeVo input, int? carFuelTypeId = null);
         CarFuelTypeVo insert(CarFuelTypeVo input);
    }
}

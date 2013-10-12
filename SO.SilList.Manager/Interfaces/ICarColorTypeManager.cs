using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ICarColorTypeManager
    {

         CarColorTypeVo get(int carColorTypeId);
         List<CarColorTypeVo> getAll(bool? isActive = true);
         CarColorTypeVm search(CarColorTypeVm input);
         bool delete(int carColorTypeId);
         CarColorTypeVo update(CarColorTypeVo input, int? carColorTypeId = null);
         CarColorTypeVo insert(CarColorTypeVo input);
    }
}

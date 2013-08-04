using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ICarManager
    {

         CarVo get(Guid carId);
         List<CarVo> getAll(bool? isActive = true);
         bool delete(Guid carId);
         CarVo update(CarVo input, Guid? carId = null);
         CarVo insert(CarVo input);
    }
}

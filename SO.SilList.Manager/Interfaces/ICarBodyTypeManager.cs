using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ICarBodyTypeManager
    {

         CarBodyTypeVo get(int carBodyTypeId);
         List<CarBodyTypeVo> getAll(bool? isActive = true);
         bool delete(int carBodyTypeId);
         CarBodyTypeVo update(CarBodyTypeVo input, int? carBodyTypeId = null);
         CarBodyTypeVo insert(CarBodyTypeVo input);
    }
}

using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ICarImageManager
    {

         CarImageVo get(Guid carImageId);
         List<CarImageVo> getAll(bool? isActive = true);
         bool delete(Guid carImageId);
         CarImageVo update(CarImageVo input, Guid? carImageId = null);
         CarImageVo insert(CarImageVo input);
    }
}

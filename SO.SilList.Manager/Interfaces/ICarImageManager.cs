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

         CarImagesVo get(Guid carImagesId);
         List<CarImagesVo> getAll(bool? isActive = true);
         bool delete(Guid carImagesId);
         CarImagesVo update(CarImagesVo input, Guid? carImagesId = null);
         CarImagesVo insert(CarImagesVo input);
    }
}

using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ICityTypeManager
    {

         CityTypeVo get(int cityTypeId);
         List<CityTypeVo> getAll(bool? isActive = true);
         CityTypeVm search(CityTypeVm input);
         bool delete(int cityTypeId);
         CityTypeVo update(CityTypeVo input, int? cityTypeId = null);
         CityTypeVo insert(CityTypeVo input);
    }
}

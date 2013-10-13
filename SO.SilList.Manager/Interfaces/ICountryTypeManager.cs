using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ICountryTypeManager
    {

         CountryTypeVo get(int carId);
         List<CountryTypeVo> getAll(bool? isActive = true);
         CountryTypeVm search(CountryTypeVm input);
         bool delete(int countryTypeId);
         CountryTypeVo update(CountryTypeVo input, int? countryTypeId = null);
         CountryTypeVo insert(CountryTypeVo input);
    }
}

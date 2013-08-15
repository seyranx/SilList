using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IRentalsManager
    {

        RentalsVo get(Guid rentalId);
         List<RentalsVo> getAll(bool? isActive = true);
         bool delete(Guid rentalId);
         RentalsVo update(RentalsVo input, Guid? rentalId = null);
         RentalsVo insert(RentalsVo input);
    }
}

using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IRentalManager
    {
        RentalVo get(Guid rentalId);
        List<RentalVo> getAll(bool? isActive = true);
        bool delete(Guid rentalId);
        RentalVo update(RentalVo input, Guid? rentalId = null);
        RentalVo insert(RentalVo input);
    }
}

using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IRentalImagesManager
    {
        RentalImageVo get(Guid rentalImageId);
        List<RentalImageVo> getAll(bool? isActive = true);
        bool delete(Guid rentalImageId);
        RentalImageVo update(RentalImageVo input, Guid? rentalImageId = null);
        RentalImageVo insert(RentalImageVo input);
    }
}

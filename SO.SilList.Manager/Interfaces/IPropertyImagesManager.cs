using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IPropertyImagesManager
    {
        PropertyImageVo get(Guid rentalImageId);
        List<PropertyImageVo> getAll(bool? isActive = true);
        bool delete(Guid rentalImageId);
        PropertyImageVo update(PropertyImageVo input, Guid? rentalImageId = null);
        PropertyImageVo insert(PropertyImageVo input);
    }
}

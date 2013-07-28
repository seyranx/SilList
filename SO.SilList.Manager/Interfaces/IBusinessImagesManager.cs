using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IBusinessImagesManager
    {
        BusinessImagesVo get(Guid imageId);
        List<BusinessImagesVo> getAll(bool? isActive = true);
        bool delete(Guid imageId);
        BusinessImagesVo update(BusinessImagesVo input, Guid? imageId = null);
        BusinessImagesVo insert(BusinessImagesVo input);
    }
}

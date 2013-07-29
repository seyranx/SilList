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
        BusinessImagesVo get(Guid businessImageId);
        List<BusinessImagesVo> getAll(bool? isActive = true);
        bool delete(Guid businessImageId);
        BusinessImagesVo update(BusinessImagesVo input, Guid? businessImageId = null);
        BusinessImagesVo insert(BusinessImagesVo input);
    }
}

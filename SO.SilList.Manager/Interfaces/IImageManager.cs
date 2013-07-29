using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IImageManager
    {
         //ImageVo getByName(string name);
         ImageVo get(Guid imageId);
         List<ImageVo> getAll(bool? isActive = true);
         bool delete(Guid imageId);
         ImageVo update(ImageVo input, Guid? imageId = null);
         ImageVo insert(ImageVo input);
    }
}

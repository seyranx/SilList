using SO.SilList.Manager.Models;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IBedroomTypeManager
    {
        BedroomTypeVo get(int bedroomTypeId);
        List<BedroomTypeVo> getAll(bool? isActive = true);
        BedroomTypeVm search(BedroomTypeVm input);
        bool delete(int bedroomTypeId);
        BedroomTypeVo update(BedroomTypeVo input, int? bedroomTypeId = null);
        BedroomTypeVo insert(BedroomTypeVo input);
    }
}

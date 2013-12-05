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
    interface IBathroomTypeManager
    {
        BathroomTypeVo get(int bathroomTypeId);
        List<BathroomTypeVo> getAll(bool? isActive = true);
        BathroomTypeVm search(BathroomTypeVm input);
        bool delete(int bathroomTypeId);
        BathroomTypeVo update(BathroomTypeVo input, int? bathroomTypeId = null);
        BathroomTypeVo insert(BathroomTypeVo input);
    }
}

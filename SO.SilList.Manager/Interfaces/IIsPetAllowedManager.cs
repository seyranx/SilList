using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IIsPetAllowedManager
    {
        IsPetAllowedTypeVo get(int isPetAllowedTypeId);
        List<IsPetAllowedTypeVo> getAll(bool? isActive = true);
        IsPetAllowedTypeVm search(IsPetAllowedTypeVm input);
        bool delete(int isPetAllowedTypeId);
        IsPetAllowedTypeVo update(IsPetAllowedTypeVo input, int? isPetAllowedTypeId = null);
        IsPetAllowedTypeVo insert(IsPetAllowedTypeVo input);
    }
}

using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IRentTypeManager
    {
        StatusTypeVo get(int rentTypeId);
        List<StatusTypeVo> getAll(bool? isActive = true);
        bool delete(int rentTypeId);
        StatusTypeVo update(StatusTypeVo input, int? rentTypeId = null);
        StatusTypeVo insert(StatusTypeVo input);
    }
}

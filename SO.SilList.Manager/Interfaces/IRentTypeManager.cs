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
        RentTypeVo get(int rentTypeId);
        List<RentTypeVo> getAll(bool? isActive = true);
        bool delete(int rentTypeId);
        RentTypeVo update(RentTypeVo input, int? rentTypeId = null);
        RentTypeVo insert(RentTypeVo input);
    }
}

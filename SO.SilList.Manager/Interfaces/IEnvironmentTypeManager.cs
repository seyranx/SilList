using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IEnvironmentTypeManager
    {
        EnvironmentTypeVo get(int IEnvironmentTypeId);
        List<EnvironmentTypeVo> getAll(bool? isActive = true);
        bool delete(int EnvironmentTypeId);
        EnvironmentTypeVo update(EnvironmentTypeVo input, int? environmentTypeId = null);
        EnvironmentTypeVo insert(EnvironmentTypeVo input);
    }
}

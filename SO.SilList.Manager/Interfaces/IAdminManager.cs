using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Interfaces
{
    interface IAdminManager
    {
        AdminVo get(int adminId);
        List<AdminVo> getAll(bool? isActive = true);
        bool delete(int adminId);
        AdminVo update(AdminVo input, int? adminId = null);
        AdminVo insert(AdminVo input);
    }
}

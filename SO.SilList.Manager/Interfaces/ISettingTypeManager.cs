using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface ISettingTypeManager
    {
        SettingTypeVo get(int settingTypeId);
        List<SettingTypeVo> getAll(bool? isActive = true);
        bool delete(int settingTypeId);
        SettingTypeVo update(SettingTypeVo input, int? settingTypeId = null);
        SettingTypeVo insert(SettingTypeVo input);
    }
}

using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IEntryStatusTypeManager
    {
        EntryStatusTypeVo get(int EntryStatusTypeVo);
        List<EntryStatusTypeVo> getAll(bool? isActive = true);
        bool delete(int EntryStatusTypeVo);
        EntryStatusTypeVo update(EntryStatusTypeVo input, int? EntryStatusTypeVo = null);
        EntryStatusTypeVo insert(EntryStatusTypeVo input);
    }
}

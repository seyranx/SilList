using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Interfaces
{
    interface IAcceptsSection8TypeManager
    {
        AcceptsSection8TypeVo get(int acceptsSection8TypeId);
        List<AcceptsSection8TypeVo> getAll(bool? isActive = true);
        AcceptsSection8TypeVm search(AcceptsSection8TypeVm input);
        bool delete(int acceptsSection8TypeId);
        AcceptsSection8TypeVo update(AcceptsSection8TypeVo input, int? acceptsSection8TypeId = null);
        AcceptsSection8TypeVo insert(AcceptsSection8TypeVo input);
    }
}

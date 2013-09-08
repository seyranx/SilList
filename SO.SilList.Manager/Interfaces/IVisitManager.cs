using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;


namespace SO.SilList.Manager.Interfaces
{
    public interface IVisitManager
    {
        VisitVm search(VisitVm input);

        VisitVo insert(VisitVo input);

        // delete everything older than given date
        int delete(DateTime input);
    }
}

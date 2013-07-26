using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ILeasingTermTypeManager
    {

        LeaseTermTypeVo get(int leaseTermTypeId);
        List<LeaseTermTypeVo> getAll(bool? isActive = true);
        bool delete(int leaseTermTypeId);
        LeaseTermTypeVo update(LeaseTermTypeVo input, int? leaseTermTypeId = null);
         LeaseTermTypeVo insert(LeaseTermTypeVo input);
    }
}

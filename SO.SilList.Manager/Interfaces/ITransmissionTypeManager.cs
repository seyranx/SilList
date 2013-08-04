using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface ITransmissionTypeManager
    {

        TransmissionTypeVo get(int transmissionTypeId);
        List<TransmissionTypeVo> getAll(bool? isActive = true);
        bool delete(int transmissionTypeId);
        TransmissionTypeVo update(TransmissionTypeVo input, int? transmissionTypeId = null);
         TransmissionTypeVo insert(TransmissionTypeVo input);
    }
}

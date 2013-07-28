using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IBusinessRatingsManager
    {
         BusinessRatingsVo get(Guid ratingId);
         List<BusinessRatingsVo> getAll(bool? isActive = true);
         bool delete(Guid ratingId);
         BusinessRatingsVo update(BusinessRatingsVo input, Guid? ratingId = null);
         BusinessRatingsVo insert(BusinessRatingsVo input);
    }
}

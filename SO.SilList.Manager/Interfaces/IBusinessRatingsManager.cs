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
         BusinessRatingsVo get(Guid businessRatingId);
         List<BusinessRatingsVo> getAll(bool? isActive = true);
         bool delete(Guid businessRatingId);
         BusinessRatingsVo update(BusinessRatingsVo input, Guid? businessRatingId = null);
         BusinessRatingsVo insert(BusinessRatingsVo input);
    }
}

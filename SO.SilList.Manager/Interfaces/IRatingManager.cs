using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IRatingManager
    {
         RatingVo get(Guid businessId);
         List<RatingVo> getAll(bool? isActive=true);
         bool delete(Guid ratingId);
         RatingVo update(RatingVo input, Guid? ratingId = null);
         RatingVo insert(RatingVo input);
    }
}

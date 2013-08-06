using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Interfaces
{
    interface IListingTypeManager
    {
        ListingTypeVo get(int listingTypeId);
        List<ListingTypeVo> getAll(bool? isActive = true);
        bool delete(int listingTypeId);
        ListingTypeVo update(ListingTypeVo input, int? listingTypeId = null);
        ListingTypeVo insert(ListingTypeVo input);
    }
}

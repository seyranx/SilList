using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Interfaces
{
    interface IListingCategoryTypeManager
    {
        ListingCategoryTypeVo get(int listingCategoryTypeId);
        List<ListingCategoryTypeVo> getAll(bool? isActive = true);
        bool delete(int listingCategoryTypeId);
        ListingCategoryTypeVo update(ListingCategoryTypeVo input, int? listingCategoryTypeId = null);
        ListingCategoryTypeVo insert(ListingCategoryTypeVo input);
    }
}

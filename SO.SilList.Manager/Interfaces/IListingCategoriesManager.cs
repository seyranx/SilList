using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Interfaces
{
    interface IListingCategoriesManager
    {
        ListingCategoriesVo get(Guid listingCategoryId);
        List<ListingCategoriesVo> getAll(bool? isActive = true);
        bool delete(Guid listingCategoryId);
        ListingCategoriesVo update(ListingCategoriesVo input, Guid? listingCategoryId = null);
        ListingCategoriesVo insert(ListingCategoriesVo input);
    }
}

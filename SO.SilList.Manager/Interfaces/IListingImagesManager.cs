using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Interfaces
{
    interface IListingImagesManager
    {
        ListingImagesVo get(Guid listingImageId);
        List<ListingImagesVo> getAll(bool? isActive = true);
        bool delete(Guid listingImageId);
        ListingImagesVo update(ListingImagesVo input, Guid? listingImageId = null);
        ListingImagesVo insert(ListingImagesVo input);
    }
}

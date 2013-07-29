using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IListingDetailManager
    {
        //ListingDetailVo getByName(string name);
        ListingDetailVo get(Guid listingDetailId);
        List<ListingDetailVo> getAll(bool? isActive = true);
        bool delete(Guid listingDetailId);
        ListingDetailVo update(ListingDetailVo input, Guid? listingDetailId = null);
        ListingDetailVo insert(ListingDetailVo input);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Manager.Interfaces
{
    interface IListingManager
    {
        ListingVo get(Guid listingId);
        List<ListingVo> getAll(bool? isActive = true);
        bool delete(Guid listingId);
        ListingVo update(ListingVo input, Guid? listingId = null);
        ListingVo insert(ListingVo input);

        //int count(ListingVm input);
        //List<ListingVm> search(ListingVm input);
    }
}
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;

namespace SO.SilList.Manager.Managers
{
    public class ListingDetailManager : IListingDetailManager
    {
        /// <summary>
        /// Find ListingDetail matching the listingDetailId (primary key)
        /// </summary>
        public ListingDetailVo get(Guid listingDetailId)
        {
            using (var db = new MainDb())
            {
                var res = db.listingDetails
                            //.Include(x => x.xxxx)
                            .FirstOrDefault(p => p.listingDetailId == listingDetailId);

                return res;
            }
        }

        public List<ListingDetailVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(Guid listingDetailId)
        {
            throw new NotImplementedException();
        }

        public ListingDetailVo update(ListingDetailVo input, Guid? listingDetailId = null)
        {
            throw new NotImplementedException();
        }

        public ListingDetailVo insert(ListingDetailVo input)
        {
            throw new NotImplementedException();
        }
    }
}

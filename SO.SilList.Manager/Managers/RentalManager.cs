using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Managers
{
    public class RentalManager: IRentalManager
    {
        public RentalVo get(Guid rentalId)
        {
            using (var db = new MainDb())
            {
                var result = db.rental
                            .FirstOrDefault(r => r.rentalId == rentalId);

                return result;
            }
        }

        public List<RentalVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(Guid rentalId)
        {
            throw new NotImplementedException();
        }

        public RentalVo update(RentalVo input, Guid? rentalId = null)
        {
            throw new NotImplementedException();
        }

        public RentalVo insert(RentalVo input)
        {
            throw new NotImplementedException();
        }
    }
}

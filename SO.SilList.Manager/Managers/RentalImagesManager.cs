using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Managers
{
    class RentalImagesManager : IRentalImagesManager
    {
        public RentalImageVo get(int rentalImageId)
        {
            throw new NotImplementedException();
        }

        public List<RentalImageVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(int rentalImageId)
        {
            throw new NotImplementedException();
        }

        public RentalImageVo update(RentalImageVo input, int? rentalImageId = null)
        {
            throw new NotImplementedException();
        }

        public RentalImageVo insert(Models.ValueObjects.RentalImageVo input)
        {
            throw new NotImplementedException();
        }
    }
}

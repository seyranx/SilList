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
    public class RentTypeManager : IRentTypeManager
    {
        public RentTypeVo get(int rentTypeId)
        {
            throw new NotImplementedException();
        }

        public List<RentTypeVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(int rentTypeId)
        {
            throw new NotImplementedException();
        }

        public RentTypeVo update(RentTypeVo input, int? rentTypeId = null)
        {
            throw new NotImplementedException();
        }

        public RentTypeVo insert(RentTypeVo input)
        {
            throw new NotImplementedException();
        }
    }
}

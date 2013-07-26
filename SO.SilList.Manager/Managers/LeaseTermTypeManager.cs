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
    public class LeaseTermTypeManager : ILeasingTermTypeManager
    {

        public LeaseTermTypeVo get(int leaseTermTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.leaseTermType
                            .FirstOrDefault(L => L.leaseTermTypeId == leaseTermTypeId);

                return result;
            }
        }

        public List<LeaseTermTypeVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(int leaseTermTypeId)
        {
            throw new NotImplementedException();
        }

        public LeaseTermTypeVo update(LeaseTermTypeVo input, int? leaseTermTypeId = null)
        {
            throw new NotImplementedException();
        }

        public LeaseTermTypeVo insert(LeaseTermTypeVo input)
        {
            throw new NotImplementedException();
        }
    }
}

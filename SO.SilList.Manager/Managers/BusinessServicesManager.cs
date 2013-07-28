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
    class BusinessServicesManager : IBusinessServicesManager
    {
        public BusinessServicesManager() { }

        public BusinessServicesVo get(int serviceTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessServices
                            
                            .FirstOrDefault(p => p.serviceTypeId == serviceTypeId);
                return res;
            }
        }

        public List<BusinessServicesVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(int serviceTypeId)
        {
            throw new NotImplementedException();
        }

        public BusinessServicesVo update(BusinessServicesVo input, int? serviceTypeId = null)
        {
            throw new NotImplementedException();
        }

        public BusinessServicesVo insert(BusinessServicesVo input)
        {
            throw new NotImplementedException();
        }
    }
}

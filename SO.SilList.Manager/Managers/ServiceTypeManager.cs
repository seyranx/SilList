using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using EntityFramework.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Managers
{
    class ServiceTypeManager : IServiceTypeManager
    {

        public ServiceTypeManager() { }

        /// <summary>
        /// Find The servicetype with matching the name
        /// </summary>
        public ServiceTypeVo getByName(string name)
        {
            using (var db = new MainDb())
            {
                var res = db.serviceTypes.FirstOrDefault(e => e.name == name);

                return res;
            }
        }

        public ServiceTypeVo get(int serviceTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.serviceTypes
                            .FirstOrDefault(p => p.serviceTypeId == serviceTypeId);
                return res;
            }
        }

        public List<ServiceTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.serviceTypes 
                    
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(int serviceTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.serviceTypes 
                     .Where(e => e.serviceTypeId  == serviceTypeId)
                     .Delete();
                return true;
            }
        }

        public ServiceTypeVo update(ServiceTypeVo input, int? serviceTypeId = null)
        {
            throw new NotImplementedException();
        }

        public ServiceTypeVo insert(ServiceTypeVo input)
        {
            throw new NotImplementedException();
        }
    }
}

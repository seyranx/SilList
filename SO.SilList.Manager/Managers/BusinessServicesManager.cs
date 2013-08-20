using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Managers
{
    public class BusinessServicesManager : IBusinessServicesManager
    {
        public BusinessServicesManager() { }

        public BusinessServicesVo get(Guid businessServiceId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessServices
                            .Include(s => s.business)
                            .Include(t => t.serviceType)
                            .FirstOrDefault(p => p.businessServiceId == businessServiceId);
                return res;
            }
        }

        public List<BusinessServicesVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.businessServices
                             .Include(s => s.business)
                             .Include(t => t.serviceType)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(Guid businessServiceId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessServices
                     .Where(e => e.businessServiceId == businessServiceId)
                     .Delete();
                return true;
            }
        }

        public BusinessServicesVo update(BusinessServicesVo input, Guid? businessServiceId = null)
        {
            using (var db = new MainDb())
            {

                if (businessServiceId == null)
                    businessServiceId = input.businessServiceId;

                var res = db.businessServices.FirstOrDefault(e => e.businessServiceId == businessServiceId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public BusinessServicesVo insert(BusinessServicesVo input)
        {
            using (var db = new MainDb())
            {

                db.businessServices.Add(input);
                db.SaveChanges();

                return input;
            }
        }
        public int count()
        {
            using (var db = new MainDb())
            {
                return db.businessServices .Count();
            }
        }
    }
}

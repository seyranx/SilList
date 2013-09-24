using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using EntityFramework.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Manager.Managers
{
    public class ServiceTypeManager : IServiceTypeManager
    {

        public ServiceTypeManager() { }

        /// <summary>
        /// Find The servicetype with matching the name
        /// </summary>
        public ServiceTypeVo getByName(string name)
        {
            using (var db = new MainDb())
            {
                var res = db.serviceTypes
                    .Include(s => s.site)
                    .FirstOrDefault(e => e.name == name);
                return res;
            }
        }

        public ServiceTypeVo get(int serviceTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.serviceTypes
                            .Include(s=>s.site)
                            .FirstOrDefault(p => p.serviceTypeId == serviceTypeId);
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public ServiceTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.serviceTypes
                //            .Include(s =>s.site)
                            .FirstOrDefault();

                return res;
            }
        }

        public List<ServiceTypeVo> search(ServiceTypeVm input)
        {

            using (var db = new MainDb())
            {
                var list = db.serviceTypes
                             .Include(s => s.site)
                             .OrderBy(b => b.name)
                             .Skip(input.skip)
                             .Take(input.rowCount)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.name.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                                    )
                             .ToList();

                return list;
            }
        }

        public List<ServiceTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.serviceTypes
                             .Include(s => s.site)                    
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
            using (var db = new MainDb())
            {

                if (serviceTypeId  == null)
                    serviceTypeId = input.serviceTypeId;

                var res = db.serviceTypes.FirstOrDefault(e => e.serviceTypeId == serviceTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


 //               input.created = res.created;
 //               input.createdBy = res.createdBy;
 //               db.Entry(res).CurrentValues.SetValues(input);

                db.SaveChanges();
                return res;

            }
        }

        public ServiceTypeVo insert(ServiceTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.serviceTypes.Add(input);
                db.SaveChanges();

                return input;
            }
        }
        public int count()
        {
            using (var db = new MainDb())
            {
                return db.serviceTypes.Count();
            }
        }
    }
}

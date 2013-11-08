using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Manager.Managers
{
    public class RentalManager: IRentalManager
    {
        public PropertyVo get(Guid rentalId)
        {
            using (var db = new MainDb())
            {
                var result = db.rental
                            .Include(r => r.propertyType)
                            .Include(t => t.propertyListingType)
                            .Include(c => c.rentType)
                            .Include(s => s.site)
                            .Include(m => m.member)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 
                            .FirstOrDefault(r => r.propertyId == rentalId);

                return result;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public PropertyVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.rental
                            .FirstOrDefault();

                return res;
            }
        }
        
        public RentalVm search(RentalVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.rental
                            .Include(r => r.propertyType)
                            .Include(t => t.propertyListingType)
                            .Include(c => c.rentType)
                            .Include(s => s.site)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 
                            .OrderBy(b => b.description)
                            .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.description.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                             );
                input.paging.totalCount = query.Count();
                input.result = query
                             .Skip(input.paging.skip)
                             .Take(input.paging.rowCount)

                             .ToList();

                return input;
            }
        }
         
        public List<PropertyVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.rental
                            .Include(r => r.propertyType)
                            .Include(t => t.propertyListingType)
                            .Include(c => c.rentType)
                            .Include(s => s.site)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 

                            .Where(e => isActive == null || e.isActive == isActive)
                            .ToList();

                return list;
            }
        }

        public bool delete(Guid rentalId)
        {
            using (var db = new MainDb())
            {
                var res = db.rental
                     .Where(e => e.propertyId == rentalId)
                     .Delete();
                return true;
            }
        }

        public PropertyVo update(PropertyVo input, Guid? rentalId = null)
        {
            using (var db = new MainDb())
            {

                if (rentalId == null)
                    rentalId = input.propertyId;

                var res = db.rental.FirstOrDefault(e => e.propertyId == rentalId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public PropertyVo insert(PropertyVo input)
        {
            using (var db = new MainDb())
            {

                db.rental.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.rental.Count();
            }
        }

        /*
        public List<RentalVo> search(RentalVm input)
        {
            using (var db = new MainDb())
            {
                var list = db.rental
                    .Include(r => r.propertyType)
                    .Include(t => t.leaseTermType)
                    .Include(c => c.rentType)
                    .Include(s => s.site)
                    .Where(e => (input.isActive == null || e.isActive == input.isActive)
                        && (e.title.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword)))
                    .OrderBy(o => o.title)
                    .Skip(input.skip)
                    .Take(input.rowCount)
                    .ToList();

                return list;
            }
        }
         */
         
    }
}

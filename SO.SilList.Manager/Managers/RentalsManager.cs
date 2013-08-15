using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Managers
{
    public class RentalsManager: IRentalsManager
    {
        public RentalsVo get(Guid rentalId)
        {
            using (var db = new MainDb())
            {
                var result = db.rentals 
                            .FirstOrDefault(r => r.rentalId == rentalId);

                return result;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public RentalsVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.rentals
                            .FirstOrDefault();

                return res;
            }
        }

        public List<RentalsVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.rentals
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(Guid rentalId)
        {
            using (var db = new MainDb())
            {
                var res = db.rentals
                     .Where(e => e.rentalId == rentalId)
                     .Delete();
                return true;
            }
        }

        public RentalsVo update(RentalsVo input, Guid? rentalId = null)
        {
            using (var db = new MainDb())
            {

                if (rentalId == null)
                    rentalId = input.rentalId;

                var res = db.rentals.FirstOrDefault(e => e.rentalId == rentalId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public RentalsVo insert(RentalsVo input)
        {
            using (var db = new MainDb())
            {

                db.rentals.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.rentals.Count();
            }
        }
    }
}

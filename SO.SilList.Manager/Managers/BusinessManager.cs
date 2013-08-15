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

namespace SO.SilList.Manager.Managers
{
    public class BusinessManager : IBusinessManager
    {

        public BusinessManager()
        {

        }

        /// <summary>
        /// Find The business with matching the name
        /// </summary>
        public BusinessVo getByName(string name)
        {
            using (var db = new MainDb())
            {
                var res = db.businesses
                             .Include(s => s.site)
                            .FirstOrDefault(e => e.name == name);
                return res;
            }
        }

        /// <summary>
        /// Find Businesses matching the businessId (primary key)
        /// </summary>
        public BusinessVo get(Guid businessId)
        {
            using (var db = new MainDb())
            {
                var res = db.businesses
                            .Include(s => s.site)
                            .FirstOrDefault(p => p.businessId == businessId);
                 
                return res;
            }
        }
         
        /// <summary>
        /// Get First Item
        /// </summary>
        public BusinessVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.businesses
                            //.Include(s=>s.site)
                            .FirstOrDefault();
               
                return res;
            }
        }

        //
        public List<BusinessVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.businesses
                             .Include(s => s.site)
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(Guid businessId)
        {
            using (var db = new MainDb())
            {
                var res = db.businesses
                     .Where(e => e.businessId == businessId)
                     .Delete();
                return true;
            }
        }

        public BusinessVo update(BusinessVo input, Guid? businessId= null)
        {
        
            using (var db = new MainDb())
            {

                if (businessId == null)
                    businessId = input.businessId; 

                var res = db.businesses.FirstOrDefault(e => e.businessId == businessId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public BusinessVo insert(BusinessVo input)
        {
            using (var db = new MainDb())
            {
                
                db.businesses.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.businesses.Count();
            }
        }

        
    }
}

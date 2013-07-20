using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.DbContexts;
using SO.SilList.Manager.ValueObjects.AppData.All;
using System.Data.Entity;
using SO.Manager.Interfaces;
using EntityFramework.Extensions;

namespace SO.SilList.Manager.Managers
{
    public class BusinessManager : IBusinessManager
    {

        public BusinessManager()
        {

        }

        public BusinessVo findByName(string name)
        {
            using (var db = new SilListDb())
            {
                var res = db.businesses.FirstOrDefault(e => e.name == name);

                return res;
            }
        }


        public BusinessVo find(Guid businessId)
        {
            using (var db = new SilListDb())
            {
                var res = db.businesses.FirstOrDefault(e => e.businessId == businessId);
                 
                return res;
            }
        }

        public List<BusinessVo> findAll(bool? isActive=true)
        {
            using (var db = new SilListDb())
            {
                var list = db.businesses.Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(Guid businessId)
        {
            using (var db = new SilListDb())
            {
                var res = db.businesses
                     .Where(e => e.businessId == businessId)
                     .Delete();
                return true;
            }
        }

        public BusinessVo update(BusinessVo input, Guid businessId=-1)
        {
        
            using (var db = new SilListDb())
            {

                if (businessId == -1)
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
            using (var db = new SilListDb())
            {
                
                db.businesses.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public Guid count()
        {
            using (var db = new SilListDb())
            {
                return db.businesses.Count();
            }
        }

        
    }
}

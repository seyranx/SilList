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
    public class BusinessCategoryTypeManager : IBusinessCategoryTypeManager
    {
        public BusinessCategoryTypeVo get(int businessCategoryTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.businessCategoryType
                            .FirstOrDefault(b => b.businessCategoryTypeId == businessCategoryTypeId);

                return result;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public BusinessCategoryTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.businessCategoryType
                            .FirstOrDefault();

                return res;
            }
        }

        public List<BusinessCategoryTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.businessCategoryType
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(int businessCategoryTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessCategoryType
                     .Where(e => e.businessCategoryTypeId == businessCategoryTypeId)
                     .Delete();
                return true;
            }
        }

        public BusinessCategoryTypeVo update(BusinessCategoryTypeVo input, int? businessCategoryTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (businessCategoryTypeId == null)
                    businessCategoryTypeId = input.businessCategoryTypeId;

                var res = db.businessCategoryType.FirstOrDefault(e => e.businessCategoryTypeId == businessCategoryTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public BusinessCategoryTypeVo insert(BusinessCategoryTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.businessCategoryType.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.businessCategoryType.Count();
            }
        }
    }
}

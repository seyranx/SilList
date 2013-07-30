using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Managers
{
    public class BusinessCategoriesManager : IBusinessCategoriesManager
    {

        /// <summary>
        /// Find 'BusinessCategories'
        /// </summary>
        public BusinessCategoriesVo get(Guid businessCategoryId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessCategories
                            //.Include(s => s.site)
                            .FirstOrDefault(p => p.businessCategoryId == businessCategoryId);

                return res;
            }
        }

        /// <summary>
        /// Get All items
        /// </summary>
        public List<BusinessCategoriesVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.businessCategories
                             //.Include(s => s.site)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public BusinessCategoriesVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.businessCategories
                            //.Include(s => s.site)
                            .FirstOrDefault();

                return res;
            }
        }

        /// <summary>
        /// Delete item given the ratingID
        /// </summary>
        public bool delete(Guid businessCategoryId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessCategories
                     .Where(e => e.businessCategoryId == businessCategoryId)
                     .Delete();
                return true;
            }
        }

        /// <summary>
        /// update the table
        /// </summary>
        public BusinessCategoriesVo update(BusinessCategoriesVo input, Guid? businessCategoryId = null)
        {
            using (var db = new MainDb())
            {

                if (businessCategoryId == null)
                    businessCategoryId = input.businessCategoryId;

                var res = db.businessCategories.FirstOrDefault(e => e.businessCategoryId == businessCategoryId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public BusinessCategoriesVo insert(BusinessCategoriesVo input)
        {
            using (var db = new MainDb())
            {

                db.businessCategories.Add(input);
                db.SaveChanges();

                return input;
            }
        }


    }
}

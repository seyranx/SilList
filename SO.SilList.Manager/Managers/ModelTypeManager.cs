using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SO.SilList.Manager.Managers
{
    public class ModelTypeManager : IModelTypeManager
    {
        public ModelTypeVo get(int modelTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.modelType
                            .Include(m => m.makeType)
                            .FirstOrDefault(r => r.modelTypeId == modelTypeId);

                return result;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public ModelTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.modelType
                            .Include(m => m.makeType)
                            .FirstOrDefault();

                return res;
            }
        }
        
        public List<ModelTypeVo> getAll(bool? isActive = true, int? makeTypeId =null)
        {
            using (var db = new MainDb())
            {
                var list = db.modelType
                             .Include(m => m.makeType)
                            .Where(e => isActive == null || e.isActive == isActive)
                             .Where(e => makeTypeId==null || e.makeTypeId == makeTypeId)
                             
                             .ToList();

                return list;
            }
        }

        public bool delete(int modelTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.modelType
                     .Where(e => e.modelTypeId == modelTypeId)
                     .Delete();
                return true;
            }
        }

        public ModelTypeVo update(ModelTypeVo input, int? modelTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (modelTypeId == null)
                    modelTypeId = input.modelTypeId;

                var res = db.modelType.FirstOrDefault(e => e.modelTypeId == modelTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public ModelTypeVo insert(ModelTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.modelType.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.modelType.Count();
            }
        }
    }
}

using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Managers
{
    public class EnvironmentTypeManager : IEnvironmentTypeManager 
    {
        public EnvironmentTypeVo get(int environmentTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.environmentTypes
                            .FirstOrDefault(b => b.environmentTypeId == environmentTypeId);

                return result;
            }
        }

        public List<EnvironmentTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.environmentTypes
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(int EnvironmentTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.environmentTypes
                     .Where(e => e.environmentTypeId == EnvironmentTypeId)
                     .Delete();
                return true;
            }
        }

        public Models.ValueObjects.EnvironmentTypeVo update(Models.ValueObjects.EnvironmentTypeVo input, int? environmentTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (environmentTypeId == null)
                    environmentTypeId = input.environmentTypeId;

                var res = db.environmentTypes.FirstOrDefault(e => e.environmentTypeId == environmentTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;
            }
        }

        public EnvironmentTypeVo insert(Models.ValueObjects.EnvironmentTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.environmentTypes.Add(input);
                db.SaveChanges();

                return input;
            }
        }
    }
}

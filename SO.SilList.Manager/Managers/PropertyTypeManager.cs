using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;

namespace SO.SilList.Manager.Managers
{
    public class PropertyTypeManager : IPropertyTypeManager
    {
        public PropertyTypeVo get(int propertyTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.propertyTypes
                    //.Include(s => s.image)
                            .FirstOrDefault(p => p.propertyTypeId == propertyTypeId);

                return res;
            }
        }

        public List<PropertyTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.propertyTypes
                             //.Include(s => s.site)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(int propertyTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.propertyTypes
                     .Where(e => e.propertyTypeId == propertyTypeId)
                     .Delete();
                return true;
            }
        }

        public PropertyTypeVo update(PropertyTypeVo input, int? propertyTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (propertyTypeId == null)
                    propertyTypeId = input.propertyTypeId;

                var res = db.propertyTypes.FirstOrDefault(e => e.propertyTypeId == propertyTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public PropertyTypeVo insert(PropertyTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.propertyTypes.Add(input);
                db.SaveChanges();

                return input;
            }
        }
    }
}

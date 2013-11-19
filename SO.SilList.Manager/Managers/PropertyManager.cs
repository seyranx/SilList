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
    public class PropertyManager: IPropertyManager
    {
        public PropertyVo get(Guid propertyId)
        {
            using (var db = new MainDb())
            {
                var result = db.properties
                            .Include(r => r.propertyType)
                            .Include(t => t.propertyListingType)
                            .Include(c => c.statusType)
                            .Include(s => s.site)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 
                            .FirstOrDefault(r => r.propertyId == propertyId);

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
                var res = db.properties
                            .FirstOrDefault();

                return res;
            }
        }
        
        public PropertyVm search(PropertyVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.properties
                            .Include(r => r.propertyType)
                            .Include(t => t.propertyListingType)
                            .Include(c => c.statusType)
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
                var list = db.properties
                            .Include(r => r.propertyType)
                            .Include(t => t.propertyListingType)
                            .Include(c => c.statusType)
                            .Include(s => s.site)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 

                            .Where(e => isActive == null || e.isActive == isActive)
                            .ToList();

                return list;
            }
        }

        public bool delete(Guid propertyId)
        {
            using (var db = new MainDb())
            {
                var res = db.properties
                     .Where(e => e.propertyId == propertyId)
                     .Delete();
                return true;
            }
        }

        public PropertyVo update(PropertyVo input, Guid? propertyId = null)
        {
            using (var db = new MainDb())
            {

                if (propertyId == null)
                    propertyId = input.propertyId;

                var res = db.properties.FirstOrDefault(e => e.propertyId == propertyId);

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

                db.properties.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.properties.Count();
            }
        }         
    }
}

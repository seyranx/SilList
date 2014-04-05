using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions; 
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Managers.Base;

using SO.Utility.Classes; 
using SO.Utility.Models.ViewModels;
using SO.Utility;
using SO.Utility.Helpers;
using SO.Utility.Extensions;




namespace  SO.SilList.Manager.Managers 
{ 
    public class PropertyManager : PropertyManagerBase
    {
	 
        public PropertyManager()
        {
		 
        }

        /// <summary>
        /// Get Property by Id
        /// </summary>
        public PropertyVo get(Guid propertyId)
        {
            using (var db = new MainDb())
            {
                var result = db.properties
                            .Include(r => r.propertyType)
                            .Include(t => t.propertyListingType)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType)
                                //.Include(a => a.acceptsSection8Type)
                            .FirstOrDefault(r => r.propertyId == propertyId);

                return result;
            }
        }

        /// <summary>
        /// Get All Properties by a Member
        /// </summary>
        public List<PropertyVo> getAll(int memberId, bool? isActive = null)
        {
            using (var db = new MainDb())
            {
                var list = db.properties
                            .Include(r => r.propertyType)
                            .Include(t => t.propertyListingType)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType)
                            .Where(e => (isActive == null || e.isActive == isActive)
                                    && (memberId == null || e.createdBy == memberId))
                                    .ToList();

                return list;
            }
        }

        /// <summary>
        /// Delete a Property
        /// </summary>
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

        /// <summary>
        /// Update a Property 
        /// </summary>
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

        /// <summary>
        /// Update a Property 
        /// </summary>
        public PropertyVo insert(PropertyVo input)
        {
            using (var db = new MainDb())
            {

                db.properties.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        /// <summary>
        /// Update a Property 
        /// </summary>
        public int count()
        {
            using (var db = new MainDb())
            {
                return db.properties.Count();
            }
        }

        /// <summary>
        /// Approve, Decline
        /// </summary>
        ////////////////////////////////////////////////
        // Entry Status Type stuff
     
    }
}


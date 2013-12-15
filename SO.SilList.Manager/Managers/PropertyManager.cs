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
                            .Include(c => c.entryStatusType)
                            .Include(s => s.site)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 
                            .Include(a => a.acceptsSection8Type)
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
            DateTime listingDate = new DateTime();
            listingDate = DateTime.Today.Date;
            if (input.listingDate != null)
            {
                switch (input.listingDate)
                {
                    case 0: //last 1 day
                        listingDate = listingDate.Subtract(new TimeSpan(1, 0, 0, 0, 0));
                        break;
                    case 1: //last 3 days
                        listingDate = listingDate.Subtract(new TimeSpan(3, 0, 0, 0, 0));
                        break;
                    case 2: //last 7 days
                        listingDate = listingDate.Subtract(new TimeSpan(7, 0, 0, 0, 0));
                        break;
                    case 3: //2 weeks
                        listingDate = listingDate.Subtract(new TimeSpan(14, 0, 0, 0, 0));
                        break;
                    case 4: // last month
                        listingDate = listingDate.Subtract(new TimeSpan(31, 0, 0, 0, 0));
                        break;
                    case 5: // last Two month
                        listingDate = listingDate.Subtract(new TimeSpan(62, 0, 0, 0, 0));
                        break;
                }
            }

            using (var db = new MainDb())
            {
                var query = db.properties
                            .Include(r => r.propertyType)
                            .Include(t => t.propertyListingType)  
                            .Include(s => s.site)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType)
                            .Include(w => w.entryStatusType)
                            .OrderByDescending(b => b.created)
                            .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && ((e.title.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                                            || (e.title.Contains(input.keyword) || e.description.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword)))
                                      && (input.propertyTypeId == null || e.propertyTypeId == input.propertyTypeId)
                                      && (input.propertyListingTypeId == null || e.propertyListingTypeId == input.propertyListingTypeId)
                                      && (e.bedroomTypeId >= input.bedroomTypeId || input.bedroomTypeId == null)
                                      && (e.bathroomTypeId >= input.bathroomTypeId || input.bathroomTypeId == null) 
                                      && ((e.price >= input.startingPrice || input.startingPrice == null)
                                      && (e.price <= input.endingPrice || input.endingPrice == null))
                                      && (input.acceptsSection8TypeId == null || e.acceptsSection8TypeId == input.acceptsSection8TypeId)
                                      && (input.isPetAllowedTypeId == null || e.isPetAllowedTypeId == input.isPetAllowedTypeId)

                                      /*
                                      && (input.showPendingOnly == null || input.showPendingOnly == false || e.entryStatusType.name.Equals(EntryStatusTypeStrings.csPending)) 
                                      && (input.siteId == null || e.siteId == input.siteId)
                                      //&& (input.entryStatusTypeId == null || e.entryStatusType.entryStatusTypeId == input.entryStatusTypeId)
                                      && (input.listingDate ==null || DateTime.Compare(e.startDate, listingDate) >= 0)
                                       */
                             );

                input.paging.totalCount = query.Count();
                input.result = query
                             .OrderBy(b => b.title)
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
                            .Include(c => c.entryStatusType)
                            .Include(s => s.site)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 

                            .Where(e => isActive == null || e.isActive == isActive)
                            .ToList();

                return list;
            }
        }
        public List<PropertyVo> getAll(int memberId, bool? isActive = null)
        {
            using (var db = new MainDb())
            {
                var list = db.properties
                            .Include(r => r.propertyType)
                            .Include(t => t.propertyListingType)
                            .Include(c => c.entryStatusType)
                            .Include(s => s.site)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 

                            .Where(e => (isActive == null || e.isActive == isActive)
                             && (e.createdBy == memberId))
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

        ////////////////////////////////////////////////
        // Entry Status Type stuff
        public PropertyVo Approve(Guid propertyId)
        {
            using (var db = new MainDb())
            {
                var result = db.properties.FirstOrDefault(e => e.propertyId == propertyId);
                var approveRec = db.entryStatusType.FirstOrDefault(f => f.name == EntryStatusTypeStrings.csApprove);

                if (result == null) return null;

                PropertyVo input = result;
                //input.created = result.created;
                //input.createdBy = result.createdBy;
                input.entryStatusType = approveRec;
                db.Entry(result).CurrentValues.SetValues(input);

                db.SaveChanges();
                return result;


            }
        }
        public PropertyVo Decline(Guid propertyId)
        {
            using (var db = new MainDb())
            {
                var result = db.properties.FirstOrDefault(e => e.propertyId == propertyId);
                var declineRec = db.entryStatusType.FirstOrDefault(f => f.name == EntryStatusTypeStrings.csDecline);

                if (result == null) return null;

                PropertyVo input = result;
                //input.created = result.created;
                //input.createdBy = result.createdBy;
                input.entryStatusType = declineRec;
                db.Entry(result).CurrentValues.SetValues(input);

                db.SaveChanges();
                return result;
            }
        }

    }
}

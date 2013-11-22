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
                             .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 

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
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 

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
                            .Include(s=>s.site)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 

                            .FirstOrDefault();
               
                return res;
            }
        }


        public BusinessVm search(BusinessVm input)
        {
           
            using (var db = new MainDb())
            {

                var query = db.businesses
                             .Include(s => s.site)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 

                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.name.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                                      && (input.showPendingOnly == null || input.showPendingOnly == false || e.entryStatusType.name.Equals(EntryStatusTypeStrings.csPending)) 
                                    )
                             .OrderBy(b => b.name);
                           input.paging.totalCount = query.Count();
                input.result = query         
                             .Skip(input.paging.skip)
                             .Take(input.paging.rowCount)
                             .ToList();

                return input;
            }
        }
        
        public List<BusinessVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.businesses
                             .Include(s => s.site)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 

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


        public BusinessVo Approve(Guid businessId)
        {
            using (var db = new MainDb())
            {
                var result = db.businesses.FirstOrDefault(e => e.businessId == businessId);
                var approveRec = db.entryStatusType.FirstOrDefault(f => f.name == EntryStatusTypeStrings.csApprove);

                if (result == null) return null;

                BusinessVo input = result;
                //input.created = result.created;
                //input.createdBy = result.createdBy;
                input.entryStatusType = approveRec;
                db.Entry(result).CurrentValues.SetValues(input);

                db.SaveChanges();
                return result;


            }
        }
        public BusinessVo Decline(Guid businessId)
        {
            using (var db = new MainDb())
            {
                var res = db.businesses.FirstOrDefault(e => e.businessId == businessId);
                var declineRec = db.entryStatusType.FirstOrDefault(f => f.name == EntryStatusTypeStrings.csDecline);

                if (res == null) return null;

                BusinessVo input = res;
                //input.created = result.created;
                //input.createdBy = result.createdBy;
                input.entryStatusType = declineRec;
                db.Entry(res).CurrentValues.SetValues(input);

                db.SaveChanges();
                return res;
            }
        }        
    }
}

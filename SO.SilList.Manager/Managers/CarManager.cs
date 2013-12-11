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
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Manager.Managers
{
    public class CarManager : ICarManager
    {

            public CarManager()
        {

        }

        public CarVo get(Guid carId)
        {
            using (var db = new MainDb())
            {
                var result = db.car
                            .Include(s => s.site)
                            .Include(m => m.modelType)
                            .Include(l => l.modelType.makeType)
                            .Include(b => b.carBodyType)
                            .Include(t => t.transmissionType)
                            .Include(e => e.carEngineType)
                            .Include(d => d.carDoorType)
                            .Include(r => r.carDriveType)
                            .Include(f => f.carFuelType)
                            .Include(c => c.exteriorColorType)
                            .Include(c => c.interiorColorType)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 
                            .FirstOrDefault(r => r.carId == carId);

                return result;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public CarVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.car
                            .Include(s => s.site)
                            .Include(m => m.modelType)
                            .Include(l => l.modelType.makeType)
                            .Include(b => b.carBodyType)
                            .Include(t => t.transmissionType)
                            .Include(e => e.carEngineType)
                            .Include(d => d.carDoorType)
                            .Include(r => r.carDriveType)
                            .Include(f => f.carFuelType)
                            .Include(c => c.exteriorColorType)
                            .Include(c => c.interiorColorType)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 
                            .FirstOrDefault();

                return res;
            }
        }

        public CarVm search(CarVm input)
        {
             DateTime listingDate = new DateTime();
             listingDate = DateTime.Today.Date;
             if (input.listingDate != null)
             {
                 switch(input.listingDate)
                 {
                     case 0: //last 1 day
                         listingDate=listingDate.Subtract(new TimeSpan(1, 0, 0, 0, 0));
                         break;
                     case 1: //last 3 days
                         listingDate=listingDate.Subtract(new TimeSpan(3, 0, 0, 0, 0));
                         break;
                     case 2: //last 7 days
                         listingDate=listingDate.Subtract(new TimeSpan(7, 0, 0, 0, 0));
                         break;
                     case 3: //2 weeks
                         listingDate=listingDate.Subtract(new TimeSpan(14, 0, 0, 0, 0));
                         break;
                     case 4: // last month
                         listingDate =listingDate.Subtract(new TimeSpan(31, 0, 0, 0, 0));
                         break;
                     case 5: // last Two month
                         listingDate =listingDate.Subtract(new TimeSpan(62, 0, 0, 0, 0));
                         break;
                 }
             }
            using (var db = new MainDb())
            {
                var query = db.car
                            .Include(s => s.site)
                            .Include(m => m.modelType)
                            .Include(l => l.modelType.makeType)
                            .Include(b => b.carBodyType)
                            .Include(t => t.transmissionType)
                            .Include(e => e.carEngineType)
                            .Include(d => d.carDoorType)
                            .Include(r => r.carDriveType)
                            .Include(f => f.carFuelType)
                            .Include(c => c.exteriorColorType)
                            .Include(c => c.interiorColorType)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType)
                            .OrderByDescending(b => b.created)
                            .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (input.siteId == null || e.siteId == input.siteId)
                                      && (input.makeTypeId == null || e.modelType.makeTypeId == input.makeTypeId)
                                      && (input.modelTypeId == null || e.modelTypeId== input.modelTypeId)
                                      && (input.bodyTypeId == null || e.carBodyTypeId == input.bodyTypeId)
                                      && (input.driveTypeId == null || e.carDriveTypeId == input.driveTypeId)
                                      && (input.doorTypeId == null || e.carDoorTypeId == input.doorTypeId)
                                      && (input.fuelTypeId == null || e.carFuelTypeId == input.fuelTypeId)
                                      && (input.exColorTypeId == null || e.exteriorColorTypeId == input.exColorTypeId)
                                      && (input.inColorTypeId == null || e.interiorColorTypeId == input.inColorTypeId)
                                      && (input.listingDate ==null || DateTime.Compare(e.startDate, listingDate) >= 0)
                                      && ((e.year >= input.year || input.year == null)
                                            && (e.year <= input.yearTo || input.yearTo == null))
                                      && ((e.price >= input.startingPrice || input.startingPrice == null)
                                            && (e.price <= input.endingPrice || input.endingPrice == null))
                                      && ((e.millage >= input.startingMillage || input.startingMillage == null)
                                            && (e.millage <= input.endingMillage || input.endingMillage == null))
                                      && (e.vin.Contains(input.vin) || string.IsNullOrEmpty(input.vin))
                                      && (e.modelType.name.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword)
                                      || e.modelType.makeType.name.Contains(input.keyword) 
                                      || e.carBodyType.name.Contains(input.keyword)
                                      || e.carDoorType.name.Contains(input.keyword)
                                      || e.carDriveType.name.Contains(input.keyword)
                                      || e.carEngineType.name.Contains(input.keyword)
                                      || e.carFuelType.name.Contains(input.keyword)
                                   //   || e.cityType.name.Contains(input.keyword)
                                    //  || e.countryType.name.Contains(input.keyword)
                                     // || e.stateType.name.Contains(input.keyword)
                                      || e.transmissionType.name.Contains(input.keyword)
                                     // || e.address.Contains(input.keyword)
                                      || e.description.Contains(input.keyword)
                                      || e.exteriorColorType.name.Contains(input.keyword)
                                      || e.interiorColorType.name.Contains(input.keyword)
                                      || System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)e.millage).Contains(input.keyword)
                                      || System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)e.price).Contains(input.keyword)
                                      || System.Data.Objects.SqlClient.SqlFunctions.StringConvert((double)e.year).Contains(input.keyword)
                                      )
                                      && (input.showPendingOnly == null || input.showPendingOnly == false  || e.entryStatusType.name.Equals(EntryStatusTypeStrings.csPending)) 
                                      
                             );
                input.paging.totalCount = query.Count();
                input.result = query         
                             .Skip(input.paging.skip)
                             .Take(input.paging.rowCount)

                             .ToList();

                return input;
            }
        }

        public List<CarVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.car
                            .Include(s => s.site)
                            .Include(m => m.modelType)
                            .Include(l => l.modelType.makeType)
                            .Include(b => b.carBodyType)
                            .Include(t => t.transmissionType)
                            .Include(e => e.carEngineType)
                            .Include(d => d.carDoorType)
                            .Include(r => r.carDriveType)
                            .Include(f => f.carFuelType)
                            .Include(c => c.exteriorColorType)
                            .Include(c => c.interiorColorType)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();
                

                return list;
            }
        }
        public List<CarVo> getAll(int memberId, bool? isActive = null)
        {
            using (var db = new MainDb())
            {
                var list = db.car
                           .Include(s => s.site)
                           .Include(m => m.modelType)
                           .Include(l => l.modelType.makeType)
                           .Include(b => b.carBodyType)
                           .Include(t => t.transmissionType)
                           .Include(e => e.carEngineType)
                           .Include(d => d.carDoorType)
                           .Include(r => r.carDriveType)
                           .Include(f => f.carFuelType)
                           .Include(c => c.exteriorColorType)
                           .Include(c => c.interiorColorType)
                           .Include(i => i.cityType)
                           .Include(o => o.countryType)
                           .Include(u => u.stateType) 
                             .Where(e => (isActive == null || e.isActive == isActive)
                             && (e.createdBy == memberId))
                             .ToList();

                return list;
            }
        }
        public bool delete(Guid carId)
        {
            using (var db = new MainDb())
            {
                var res = db.car
                     .Where(e => e.carId == carId)
                     .Delete();
                return true;
            }
        }

        public CarVo update(CarVo input, Guid? carId = null)
        {
            using (var db = new MainDb())
            {

                if (carId == null)
                    carId = input.carId;

                var res = db.car.FirstOrDefault(e => e.carId == carId);

                if (res == null) return null;
                
                input.created = res.created;
                input.createdBy = res.createdBy;
               
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public CarVo insert(CarVo input)
        {
            using (var db = new MainDb())
            {

                db.car.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.car.Count();
            }
        }

        // Entry Status Type stuff
        public CarVo Approve(Guid carId)
        {
            using (var db = new MainDb())
            {
                var result = db.car.FirstOrDefault(e => e.carId == carId);
                var approveRec = db.entryStatusType.FirstOrDefault(f => f.name == EntryStatusTypeStrings.csApprove);

                if (result == null) return null;

                CarVo input = result;
                //input.created = result.created;
                //input.createdBy = result.createdBy;
                input.entryStatusType = approveRec;
                db.Entry(result).CurrentValues.SetValues(input);

                db.SaveChanges();
                return result;
            }
        }
        public CarVo Decline(Guid carId)
        {
            using (var db = new MainDb())
            {
                var result = db.car.FirstOrDefault(e => e.carId == carId);
                var declineRec = db.entryStatusType.FirstOrDefault(f => f.name == EntryStatusTypeStrings.csDecline);

                if (result == null) return null;

                CarVo input = result;
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

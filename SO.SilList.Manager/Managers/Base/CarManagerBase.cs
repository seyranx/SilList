using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks; 
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ValueObjects; 
using SO.SilList.Manager.DbContexts;

using SO.Utility.Classes; 
using SO.Utility.Models.ViewModels;
using SO.Utility;
using SO.Utility.Helpers;
using SO.Utility.Extensions;



 

namespace  SO.SilList.Manager.Managers.Base
{
    public class CarManagerBase
    {

        public CarManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find Car matching the carId (primary key)
        /// </summary>
        public CarVo get(Guid  carId )
        {
            using (var db = new MainDb())
            {
                var res = db.cars
                            .FirstOrDefault(p => p.carId == carId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public CarVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.cars
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.cars
                             .OrderByDescending(b => b.created)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.vin.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                                    );
             
			  if (input.paging != null) { 
					 input.paging.totalCount = query.Count();
					 query =query
                             .Skip(input.paging.skip)
                             .Take(input.paging.rowCount);
                            
				 }
                
                input.result = query.ToList<object>();
				 
                return input;
            }
        }

        //
        public List<CarVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.cars
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(Guid carId)
        {
            using (var db = new MainDb())
            {
                var res = db.cars
                     .Where(e => e.carId == carId)
                     .Delete();
                return true;
            } 
        } 

        public CarVo update(CarVo input, Guid? carId= null)
        {
        
            using (var db = new MainDb())
            {

                if (carId == null)
                    carId = input.carId; 

                var res = db.cars.FirstOrDefault(e => e.carId == carId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public CarVo insert(CarVo input)
        {
            using (var db = new MainDb())
            {
                
                db.cars.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.cars.Count();
            }
        }
		 
        
    }
}


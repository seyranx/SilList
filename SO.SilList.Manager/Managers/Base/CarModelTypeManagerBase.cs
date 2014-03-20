using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks; 
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Models.ValueObjects; 
using SO.SilList.DbContexts;
using SO.Utility.Models.ViewModels;
using SO.Utility;
using SO.Utility.Helpers;
using SO.Utility.Extensions;
 

namespace  SO.SilList.Managers.Base
{
    public class CarModelTypeManagerBase
    {

        public CarModelTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find CarModelType matching the carModelTypeId (primary key)
        /// </summary>
        public CarModelTypeVo get(int  carModelTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.carModelTypes
                            .FirstOrDefault(p => p.carModelTypeId == carModelTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public CarModelTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.carModelTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.carModelTypes
                             .OrderByDescending(b => b.created)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.name.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
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
        public List<CarModelTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.carModelTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int carModelTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.carModelTypes
                     .Where(e => e.carModelTypeId == carModelTypeId)
                     .Delete();
                return true;
            } 
        } 

        public CarModelTypeVo update(CarModelTypeVo input, int? carModelTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (carModelTypeId == null)
                    carModelTypeId = input.carModelTypeId; 

                var res = db.carModelTypes.FirstOrDefault(e => e.carModelTypeId == carModelTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public CarModelTypeVo insert(CarModelTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.carModelTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.carModelTypes.Count();
            }
        }
		 
        
    }
}


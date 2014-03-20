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
    public class CarMakeTypeManagerBase
    {

        public CarMakeTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find CarMakeType matching the carMakeTypeId (primary key)
        /// </summary>
        public CarMakeTypeVo get(int  carMakeTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.carMakeTypes
                            .FirstOrDefault(p => p.carMakeTypeId == carMakeTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public CarMakeTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.carMakeTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.carMakeTypes
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
        public List<CarMakeTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.carMakeTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int carMakeTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.carMakeTypes
                     .Where(e => e.carMakeTypeId == carMakeTypeId)
                     .Delete();
                return true;
            } 
        } 

        public CarMakeTypeVo update(CarMakeTypeVo input, int? carMakeTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (carMakeTypeId == null)
                    carMakeTypeId = input.carMakeTypeId; 

                var res = db.carMakeTypes.FirstOrDefault(e => e.carMakeTypeId == carMakeTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public CarMakeTypeVo insert(CarMakeTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.carMakeTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.carMakeTypes.Count();
            }
        }
		 
        
    }
}


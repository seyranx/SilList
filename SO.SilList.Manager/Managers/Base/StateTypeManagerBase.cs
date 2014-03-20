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
    public class StateTypeManagerBase
    {

        public StateTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find StateType matching the stateTypeId (primary key)
        /// </summary>
        public StateTypeVo get(int  stateTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.stateTypes
                            .FirstOrDefault(p => p.stateTypeId == stateTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public StateTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.stateTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.stateTypes
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
        public List<StateTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.stateTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int stateTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.stateTypes
                     .Where(e => e.stateTypeId == stateTypeId)
                     .Delete();
                return true;
            } 
        } 

        public StateTypeVo update(StateTypeVo input, int? stateTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (stateTypeId == null)
                    stateTypeId = input.stateTypeId; 

                var res = db.stateTypes.FirstOrDefault(e => e.stateTypeId == stateTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public StateTypeVo insert(StateTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.stateTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.stateTypes.Count();
            }
        }
		 
        
    }
}


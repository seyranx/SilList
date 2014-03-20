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
    public class SettingTypeManagerBase
    {

        public SettingTypeManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find SettingType matching the settingTypeId (primary key)
        /// </summary>
        public SettingTypeVo get(int  settingTypeId )
        {
            using (var db = new MainDb())
            {
                var res = db.settingTypes
                            .FirstOrDefault(p => p.settingTypeId == settingTypeId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public SettingTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.settingTypes
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.settingTypes
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
        public List<SettingTypeVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.settingTypes
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(int settingTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.settingTypes
                     .Where(e => e.settingTypeId == settingTypeId)
                     .Delete();
                return true;
            } 
        } 

        public SettingTypeVo update(SettingTypeVo input, int? settingTypeId= null)
        {
        
            using (var db = new MainDb())
            {

                if (settingTypeId == null)
                    settingTypeId = input.settingTypeId; 

                var res = db.settingTypes.FirstOrDefault(e => e.settingTypeId == settingTypeId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public SettingTypeVo insert(SettingTypeVo input)
        {
            using (var db = new MainDb())
            {
                
                db.settingTypes.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.settingTypes.Count();
            }
        }
		 
        
    }
}


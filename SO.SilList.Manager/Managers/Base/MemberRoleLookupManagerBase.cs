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
    public class MemberRoleLookupManagerBase
    {

        public MemberRoleLookupManagerBase() 
        {
		 
        }

        /// <summary>
        /// Find MemberRoleLookup matching the memberRoleLookupId (primary key)
        /// </summary>
        public MemberRoleLookupVo get(Guid  memberRoleLookupId )
        {
            using (var db = new MainDb())
            {
                var res = db.memberRoleLookups
                            .FirstOrDefault(p => p.memberRoleLookupId == memberRoleLookupId);
                  
                return res;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public MemberRoleLookupVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.memberRoleLookups
                            .FirstOrDefault();
               
                return res;
            }
        } 

		public SearchFilterVm search(SearchFilterVm input)
        {
		 
            using (var db = new MainDb())
            {
                var query = db.memberRoleLookups
                             .OrderByDescending(b => b.created)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.memberRoleTypeId.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
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
        public List<MemberRoleLookupVo> getAll(bool? isActive=true)
        {
            using (var db = new MainDb())
            {
                var list = db.memberRoleLookups
                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }


        public bool delete(Guid memberRoleLookupId)
        {
            using (var db = new MainDb())
            {
                var res = db.memberRoleLookups
                     .Where(e => e.memberRoleLookupId == memberRoleLookupId)
                     .Delete();
                return true;
            } 
        } 

        public MemberRoleLookupVo update(MemberRoleLookupVo input, Guid? memberRoleLookupId= null)
        {
        
            using (var db = new MainDb())
            {

                if (memberRoleLookupId == null)
                    memberRoleLookupId = input.memberRoleLookupId; 

                var res = db.memberRoleLookups.FirstOrDefault(e => e.memberRoleLookupId == memberRoleLookupId);

                if (res == null) return null;

                input.created = res.created;
               // input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        public MemberRoleLookupVo insert(MemberRoleLookupVo input)
        {
            using (var db = new MainDb())
            {
                
                db.memberRoleLookups.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.memberRoleLookups.Count();
            }
        }
		 
        
    }
}


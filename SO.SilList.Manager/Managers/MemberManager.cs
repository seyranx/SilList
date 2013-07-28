using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Managers
{
    public class MemberManager : IMemberManager
    {
        /// <summary>
        /// Find Member matching the memberId (primary key)
        /// </summary>
        public MemberVo get(int memberId)
        {
            using (var db = new MainDb())
            {
                var res = db.members
                            .Include(s => s.site)
                            .FirstOrDefault(p => p.memberId == memberId);

                return res;
            }
        }

        public List<MemberVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(int memberId)
        {
            throw new NotImplementedException();
        }

        public MemberVo update(MemberVo input, int? memberId = null)
        {
            throw new NotImplementedException();
        }

        public MemberVo insert(MemberVo input)
        {
            throw new NotImplementedException();
        }
    }
}

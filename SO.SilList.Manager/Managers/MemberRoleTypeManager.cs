using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Managers.Base;

using SO.Utility.Classes;
using SO.Utility.Models.ViewModels;
using SO.Utility;
using SO.Utility.Helpers;
using SO.Utility.Extensions;




namespace SO.SilList.Manager.Managers
{
    public class MemberRoleTypeManager : MemberRoleTypeManagerBase
    {

        public MemberRoleTypeManager()
        {

        }

        public int? get_USER_RoleTypeId()
        {
            var res = getRoleTypeByName("User");
            return res == null ? null : res.memberRoleTypeId as int?;
        }

        public MemberRoleTypeVo getRoleTypeByName(string roleName)
        {
            using (var db = new MainDb())
            {
                var res = db.memberRoleTypes
                            .FirstOrDefault(p => p.isActive && p.name == roleName);

                return res;
            }
        }

    }
}


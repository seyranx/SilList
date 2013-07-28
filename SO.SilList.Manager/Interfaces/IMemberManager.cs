using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SO.SilList.Manager.Interfaces
{
    interface IMemberManager
    {
         //MemberVo getByName(string name);
         MemberVo get(int memberId);
         List<MemberVo> getAll(bool? isActive = true);
         bool delete(int memberId);
         MemberVo update(MemberVo input, int? memberId = null);
         MemberVo insert(MemberVo input);
    }
}

using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Web.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private MemberManager memberManager = new MemberManager();
        private MemberRoleTypeManager memberRoleTypeManager = new MemberRoleTypeManager();
        private MemberRoleLookupManager memberRoleLookupManager = new MemberRoleLookupManager();
        
        [HttpPost]
        public ActionResult Create(MemberVo input)
        {
            ViewBag.Title = "Add New User";

            if (this.ModelState.IsValid)
            {
                input.password = CurrentMember.HashWord(input.password);

                var item = memberManager.insert(input);

                if (input.memberRoleTypes != null)
                {
                    foreach (int roleId in input.memberRoleTypes)
                    {
                        var memberRoleLookupVo = new MemberRoleLookupVo();
                        memberRoleLookupVo.memberId = input.memberId;
                        memberRoleLookupVo.memberRoleTypeId = roleId;
                        memberRoleLookupVo.isActive = true;

                        memberRoleLookupManager.insert(memberRoleLookupVo);
                    }
                }
                return RedirectToAction("Index");
            }

            return View(input);
        }

        public ActionResult Create()
        {
            var vo = new MemberVo();
            return View(vo);
        }

        public ActionResult ConfirmEmail()
        {
            return View();
        }
        [Authorize]
        public ActionResult Details()
        {
            var result = CurrentMember.member;
            return View("Details", result);
        }
        //[Authorize]
        //public ActionResult EditProfile(int id)
        //{
        //    var result = CurrentMember.member;
        //    return View("EditProfile", result);
        //}
        //[Authorize]
        //[HttpPost]
        //public ActionResult EditProfile(int id, MemberVo input)
        //{
        //    bool foundTheMatch = false;
        //    MemberVo item = memberManager.get(id);
        //    if (this.ModelState.IsValid)
        //    {
        //        if (item.memberRoleTypes != null)
        //        {
        //            foreach (MemberRoleLookupVo roleLookupVo in item.memberRoleLookupses)
        //            {
        //                foundTheMatch = false;
        //                foreach (int memberRoleId in input.memberRoleTypes)
        //                {
        //                    if (roleLookupVo.memberRoleTypeId == memberRoleId)
        //                    {
        //                        input.memberRoleTypes.Remove(memberRoleId);
        //                        foundTheMatch = true;
        //                        break;
        //                    }
        //                }
        //                if (!foundTheMatch)
        //                    memberRoleLookupManager.delete(roleLookupVo.memberRoleLookupId);
        //            }
        //        }
        //        if (input.memberRoleTypes != null)
        //        {

        //            foreach (int roleId in input.memberRoleTypes)
        //            {
        //                var memberRoleLookupVo = new MemberRoleLookupVo();
        //                memberRoleLookupVo.memberId = input.memberId;
        //                memberRoleLookupVo.memberRoleTypeId = roleId;
        //                memberRoleLookupVo.isActive = true;

        //                memberRoleLookupManager.insert(memberRoleLookupVo);

        //            }

        //        }
        //        contactInfoManager.update(input, input..contactInfoId);
        //        var res = memberManager.update(input, id);
        //        return RedirectToAction("Index");
        //    }

        //    return View(input);
        //}
	}
}
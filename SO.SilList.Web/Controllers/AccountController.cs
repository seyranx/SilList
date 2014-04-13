﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EntityFramework.Extensions;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Web.Controllers
{
    public class AccountController : Controller
    {
        MemberManager memberManager = new MemberManager();
        MemberRoleLookupManager memberRoleLookupManager = new MemberRoleLookupManager();
        MemberRoleTypeManager memberRoleTypeManager = new MemberRoleTypeManager();

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVm input)
        {

            if (this.ModelState.IsValid)
            {
                // validate user
                if (CurrentMember.validateUser(input.email, input.password))
                {
                    memberManager.updateLastLoginForMember(input.email, input.password);
                    FormsAuthentication.RedirectFromLoginPage(input.email, input.rememberMe);
                }
                else
                {
                    ViewBag.uname = input.email;
                    this.ModelState.AddModelError("", "Please check Username and Password, and try again.");
                }
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var login = new LoginVm();
            return View(login);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            CurrentMember.member = null;

            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View(new RegisterVm());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterVm input)
        {
            if (this.ModelState.IsValid)
            {
                MemberVo mem_check = memberManager.getByUsername(input.username);
                if (mem_check != null)
                {
                    ViewBag.NameExistMsg = "User with this name already exist. Please choose another name.";
                    return View(input);
                }


                MemberVo mem = new MemberVo();

                mem.username = input.username;
                mem.password = input.password;
                mem.isActive = false;

                mem.firstName = input.firstName;
                mem.lastName = input.lastName;

                mem.email = input.email;
                mem.isEmailConfirmed = false;
                mem.isEmailSubscribed = false;
                mem.lastLogin = DateTime.Now;

                // Add USER role type to the newly registered member
                if (mem.memberRoleTypes == null)
                    mem.memberRoleTypes = new List<int>();
                int? userRoleTypeId = memberRoleTypeManager.get_USER_RoleTypeId();
                if (userRoleTypeId != null)
                {
                    if (!mem.memberRoleTypes.Contains(userRoleTypeId.Value))
                        mem.memberRoleTypes.Add(userRoleTypeId.Value);
                }

                memberManager.insert(mem);

                // Init the Lookup 
                if (mem.memberRoleTypes != null)
                {
                    foreach (int roleId in mem.memberRoleTypes)
                    {
                        var memberRoleLookupVo = new MemberRoleLookupVo();
                        memberRoleLookupVo.memberId = mem.memberId;
                        memberRoleLookupVo.memberRoleTypeId = roleId;
                        memberRoleLookupVo.isActive = true;

                        memberRoleLookupManager.insert(memberRoleLookupVo);

                    }
                }

                return RedirectToAction("ConfirmEmail", "Member");
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult Profile()
        {
            var result = CurrentMember.member;
            return View("Details", result);
        }
        [Authorize]
        public ActionResult EditProfile()
        {
            var result = CurrentMember.member;
            if (result.memberRoleTypes.Count > 0)
                result.memberRoleTypes = new List<int>();
            if (result.memberRoleLookupses != null)
            {
                foreach (var item in result.memberRoleLookupses)
                {
                    result.memberRoleTypes.Add((int)item.memberRoleTypeId);
                }
            }
            return View("Edit", result);
        }
        [HttpPost]
        public ActionResult EditProfile(MemberVo input)
        {
            Edit(input);
            if (!this.ModelState.IsValid)
                return View("Edit", input);
            CurrentMember.reload();
            return View("Details", CurrentMember.member);
        }

        [Authorize]
        public ActionResult Edit(MemberVo input)
        {
            var id = CurrentMember.member.memberId;
            bool foundTheMatch = false;
            MemberVo item = memberManager.get(id);
            if (this.ModelState.IsValid)
            {
                if (item.memberRoleTypes != null)
                {
                    foreach (MemberRoleLookupVo roleLookupVo in item.memberRoleLookupses)
                    {
                        foundTheMatch = false;
                        foreach (int memberRoleId in input.memberRoleTypes)
                        {
                            if (roleLookupVo.memberRoleTypeId == memberRoleId)
                            {
                                input.memberRoleTypes.Remove(memberRoleId);
                                foundTheMatch = true;
                                break;
                            }
                        }
                        if (!foundTheMatch)
                            memberRoleLookupManager.delete(roleLookupVo.memberRoleLookupId);
                    }
                }
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
                var res = memberManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View(input);
        }
    }
}
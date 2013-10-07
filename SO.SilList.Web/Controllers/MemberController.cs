using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Web.Controllers
{
    public class MemberController : Controller
    {
        private MemberManager memberManager = new MemberManager();

        public ActionResult Manage(string username)
        {
            var member = memberManager.get(1);
            return View(member);
        }

        [HttpPost]
        public ActionResult Manage(MemberVo input)
        {
            if (this.ModelState.IsValid)
            {
                memberManager.update(input, 1);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        [HttpPost]
        public ActionResult Login(MemberLoginVm input)
        {
            if (this.ModelState.IsValid)
            {
                // validate user
                if (CurrentMember.validateUser(input.email, input.password))
                {
                    FormsAuthentication.RedirectFromLoginPage(input.email, input.rememberMe);
                }
                else
                {
                    this.ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View();
        }

        public ActionResult Login()
        {
            var login = new MemberLoginVm();
            return View(login);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            CurrentMember.member = null;

            return RedirectToAction("Index", "Home");
        }
    }
}

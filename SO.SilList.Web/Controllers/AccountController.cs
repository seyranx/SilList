using System;
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

namespace SO.Urba.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        MemberManager memberManager = new MemberManager();
        MemberRoleLookupManager memberRoleLookupManager = new MemberRoleLookupManager();
        MemberRoleTypeManager memberRoleTypeManager = new MemberRoleTypeManager();

        [HttpPost]
        public ActionResult Login(LoginVm input)
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
                    this.ModelState.AddModelError("", "Please check Username and Password, and try again.");
                }
            }

            return View();
        }

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


        public ActionResult Register()
        {
            return View(new RegisterVm());
        }

        [HttpPost]
        public ActionResult Register(RegisterVm input)
        {
            if (this.ModelState.IsValid)
            {
                MemberVo mem = new MemberVo();

                mem.username = input.username;
                mem.password = input.password;
                mem.isActive = false;

                mem.firstName = input.firstName;
                mem.lastName = input.lastName;

              
                mem.email = input.email;
                mem.isEmailConfirmed = false;
                mem.isEmailSubscribed = false;

                memberManager.insert(mem);
                return RedirectToAction("ConfirmEmail", "Member");
            }

            return View();
        }

      
	}
}
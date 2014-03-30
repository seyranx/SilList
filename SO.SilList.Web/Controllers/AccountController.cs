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

      
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SO.SilList.Admin.Web.Models;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Admin.Web.Controllers
{
    public class AccountController : Controller
    {
        private AdminManager adminManager = new AdminManager();

        public ActionResult Manage(string username)
        {
            var user = adminManager.get(username);
            return View(user);
        }

        [HttpPost]
        public ActionResult Manage(AccountManageVm input)
        {
            if (this.ModelState.IsValid)
            {
                adminManager.update(input);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        [HttpPost]
        public ActionResult Login(AccountLoginVm input)
        {
            if (this.ModelState.IsValid)
            {
                // validate user
                if (Membership.ValidateUser(input.username, input.password))
                {
                    
                    FormsAuthentication.RedirectFromLoginPage(input.username, input.rememberMe);
                    //FormsAuthentication.SetAuthCookie(input.username, input.rememberMe);
                    //need to figure out retutn URL and redirect 
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
            var login = new AccountLoginVm();
            return View(login);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();            

            return RedirectToAction("Index", "Home");
        }
    }
}

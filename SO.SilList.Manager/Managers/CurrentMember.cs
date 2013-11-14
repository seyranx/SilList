using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace SO.SilList.Manager.Managers
{
    public class CurrentMember
    {
        private static string sessionKey = "_CurrentMember";
        private static MemberManager memberManager = new MemberManager();

        public CurrentMember()
        {
        }

        public static  bool validateUser(string username, string password)
        {
            MemberVo user = memberManager.getByUsernameAndPassword(username, password);
            if (user == null)
                return false;
            
            return true;
        }

        public static IIdentity currentUser
        {
            get
            {
                try
                { 
                    return HttpContext.Current.User.Identity;
                }
                catch 
                { 
                    return null; 
                }
            }
        }

        public static bool isAuthenticated
        {
            get
            {
                try { 
                    return currentUser.IsAuthenticated; 
                }
                catch 
                { 
                    return false; 
                }
            }
        }


        #region current member

        public static MemberVo member
        {
            get
            {
                try
                {
                    if (!isAuthenticated)
                    {
                      
                        HttpContext.Current.Session[sessionKey] = null;
                        return null;
                    }

                    var mem = (MemberVo)HttpContext.Current.Session[sessionKey];

                    if (mem == null)
                    {
                        mem = memberManager.getByUsernameOrEmail(currentUser.Name);
                        if (mem != null)
                            HttpContext.Current.Session[sessionKey] = mem;
                    }

                    return mem;
                }
                catch (Exception /*ex*/)
                {
                    return null;
                }

            }
            set
            {
                try
                {
                    HttpContext.Current.Session[sessionKey] = value;
                }
                catch (Exception /*ex*/)
                { 
                    return; 
                }
            }
        }

        #endregion

    }
}

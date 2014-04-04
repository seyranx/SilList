using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Managers;
using SO.SilList;

namespace SO.SilList.Manager.Managers
{
    public class CurrentMember
    {
        private static string sessionKey = "_CurrentMember";
        private static MemberManager memberManager = new MemberManager();
        private static MemberRoleTypeManager memberRoleTypeManager = new MemberRoleTypeManager();

        public CurrentMember()
        {

        }

        public static List<string> getRoleNames()
        {
            var list = member.memberRoleLookupses.Select(c => c.memberRoleType.name).ToList();
            return list;
        }
        public static bool hasRole(string roleName)
        {

            if (!string.IsNullOrEmpty(roleName) && member != null)
            {

                var exists = member.memberRoleLookupses
                                .Any(c => c.memberRoleType.name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));

                return exists;
            }
            return false;
        }
        public static bool hasRoleOf(int? roleId)
        {

            if (roleId != null && member != null)
            {

                var exists = member.memberRoleLookupses
                                .Any(c => c.memberRoleType.memberRoleTypeId.Equals(roleId));

                return exists;
            }
            return false;
        }
        public static void reload()
        {
            member = memberManager.get(member.memberId);
        }
        public static bool validateUser(string username, string password)
        {
            string hashedPassword = HashWord(password);
            MemberVo user = memberManager.getByUsernameAndPassword(username, hashedPassword);
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
                try
                {
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
                        mem = memberManager.getByUsername(currentUser.Name);
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

        public static string HashWord(string WordToHash)
        {
            //todo: uncomment to Hash it when closer to the completion
            //return FormsAuthentication.HashPasswordForStoringInConfigFile(WordToHash, "sha1");
            return WordToHash;
        }

        #endregion

    }
}
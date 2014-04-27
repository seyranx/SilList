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
    public class MemberManager : MemberManagerBase
    {

        public MemberManager()
        {

        }

        public MemberVo getByUsernameAndPassword(string username, string hashedPassword)
        {
            using (var db = new MainDb())
            {
                MemberVo mem = null;

                try
                {
                    mem = db.members
                           .Include(a => a.memberRoleLookupses.Select(c => c.memberRoleType))
                            .FirstOrDefault(p => (p.username == username || p.email == username) && p.password == hashedPassword);

                }
                catch (Exception ex)
                {
                    mem = null;
                }

                return mem;
            }
        }

        public MemberVo getByUsername(string usernameOrEmail)
        {
            using (var db = new MainDb())
            {
                var mem = db.members
                            .Include(a => a.memberRoleLookupses.Select(c => c.memberRoleType))
                            .FirstOrDefault(p => (p.username == usernameOrEmail || p.email == usernameOrEmail));

                return mem;
            }
        }

        public MemberVo updateLastLoginForMember(string usernameOrEmail, string hashedPassword)
        {
            MemberVo member = getByUsernameAndPassword(usernameOrEmail, hashedPassword);
            if (member == null)
                return null;
            member.lastLogin = DateTime.Now;
            return update(member);
        }


        public bool CheckIfUserIdAndVerifTokenMatch(int userId, string rt)
        {
            //check userid and token matches
            using (var db = new MainDb())
            {
                bool any = (from j in db.webpages_Memberships
                            where (j.UserId == userId)
                        && (j.PasswordVerificationToken == rt)
                            //&& (j.PasswordVerificationTokenExpirationDate < DateTime.Now)
                            select j).Any();
                return any;
            }
        }


        public string GenerateRandomPassword(int length)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-*&#+";
            char[] chars = new char[length];
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }


    }
}


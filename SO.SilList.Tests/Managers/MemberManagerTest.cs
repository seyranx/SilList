using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Web.Tests.Managers
{
    [TestClass]
    public class MemberManagerTest
    {
        private MemberManager memberManager = new MemberManager();

        [TestMethod]
        public void insertTest()
        {
            MemberVo mem = new MemberVo();

            mem.username = "TestUserName";
            mem.password = "TestPassword";
            mem.isActive = false;

            mem.firstName = "TestUserFirstName";
            mem.lastName = "TestUserLastName";


            mem.email = "TestUserEmail";
            mem.isEmailConfirmed = false;
            mem.isEmailSubscribed = false;
            mem.lastLogin = DateTime.Now;

            var res = memberManager.insert(mem);

            Assert.IsTrue(res!= null); // res.createdBy != null && res.createdBy != 0);
        }
    }
}

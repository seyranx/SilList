using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class AdminManagerTest
    {
        private AdminManager adminManager = new AdminManager();

        [TestMethod]
        public void insertGetDeleteTest()
        {
            var admvo = new AdminVo();

            var result = adminManager.insert(admvo);
            Assert.IsTrue(null != result);

            int myId = result.adminId;

            result = adminManager.get(myId);
            Assert.IsTrue(null != result);
            Assert.IsTrue(result.adminId == myId);

            Assert.IsTrue(adminManager.delete(myId));

            result = adminManager.get(myId);
            Assert.IsTrue(null == result);
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class BusinessManagerTest
    {
        private BusinessManager businessManager = new BusinessManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = businessManager.getAll(null);

            Assert.IsTrue(true);
        }
    }
}

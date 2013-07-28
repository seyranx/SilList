using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class ListingDetailManagerTest
    {
        private ListingDetailManager listingDetailManager = new ListingDetailManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = listingDetailManager.getAll(null);

            Assert.IsTrue(true);
        }

    }
}

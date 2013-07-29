using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

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

        [TestMethod]
        public void insertRecordsTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                var vo = new ListingDetailVo();
                vo.isApproved = false;
                var result = listingDetailManager.insert(vo);
                if (result == null)
                {
                    Assert.IsTrue(false);
                    break;
                }
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void insertDeleteTest()
        {
            var vo = new ListingDetailVo();
            vo.isApproved = true;

            var result = listingDetailManager.insert(vo);
            var result2 = listingDetailManager.get(result.listingDetailId);

            listingDetailManager.delete(result.listingDetailId);

            var result3 = listingDetailManager.get(result.listingDetailId);

            if (result != null && result2 != null && result3 == null && result2.listingDetailId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }
    }
}

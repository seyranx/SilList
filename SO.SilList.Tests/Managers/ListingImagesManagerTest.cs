using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class ListingImagesManagerTest
    {
        private ListingImagesManager listingImagesManager = new ListingImagesManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = listingImagesManager.getAll(null);

            if (res != null)
            {
                Assert.IsTrue(true);
            }
            else Assert.IsTrue(false);
        }


        [TestMethod]
        public void insertDeleteTest()
        {
            var vo = new ListingImagesVo();
            vo.createdBy = 3;
            vo.modifiedBy = 4;

            var result = listingImagesManager.insert(vo);
            var result2 = listingImagesManager.get(result.listingImageId);

            listingImagesManager.delete(result.listingImageId);

            var result3 = listingImagesManager.get(result.listingImageId);

            if (result != null && result2 != null && result3 == null && result2.listingId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }
    }
}

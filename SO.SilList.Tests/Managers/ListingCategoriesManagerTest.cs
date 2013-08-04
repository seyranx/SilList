using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class ListingCategoriesManagerTest
    {
        private ListingCategoriesManager listingCategoriesManager = new ListingCategoriesManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = listingCategoriesManager.getAll(null);

            if (res != null)
            {
                Assert.IsTrue(true);
            }
            else Assert.IsTrue(false);
        }


        [TestMethod]
        public void insertDeleteTest()
        {
            var vo = new ListingCategoriesVo();
            vo.createdBy = 3;
            vo.modifiedBy = 4;

            var result = listingCategoriesManager.insert(vo);
            var result2 = listingCategoriesManager.get(result.listingCategoryId);

            listingCategoriesManager.delete(result.listingCategoryId);

            var result3 = listingCategoriesManager.get(result.listingCategoryId);

            if (result != null && result2 != null && result3 == null && result2.listingCategoryId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

    }
}

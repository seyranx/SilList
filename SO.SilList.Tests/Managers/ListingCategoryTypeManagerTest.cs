using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class ListingCategoryTypeManagerTest
    {
        private ListingCategoryTypeManager listingCategoryTypeManager = new ListingCategoryTypeManager();

        [TestMethod]
        public void searchTest()
        {
            var vo = new ListingCategoryTypeVm();
            vo.paging.pageNumber = 1;
            vo.keyword = "1";
            vo.isActive = null;

            var res = listingCategoryTypeManager.search(vo);

            if (res != null)
            {
                Assert.IsTrue(true);
            }
            else Assert.IsTrue(false);
        }

        [TestMethod]
        public void getAllTest()
        {

            var res = listingCategoryTypeManager.getAll(null);

            if (res != null)
            {
                Assert.IsTrue(true);
            }
            else Assert.IsTrue(false);
        }


        [TestMethod]
        public void insertDeleteTest()
        {
            var vo = new ListingCategoryTypeVo();
            vo.name = "name";
            vo.description = "good job";

            var result = listingCategoryTypeManager.insert(vo);
            var result2 = listingCategoryTypeManager.get(result.listingCategoryTypeId);

            listingCategoryTypeManager.delete(result.listingCategoryTypeId);

            var result3 = listingCategoryTypeManager.get(result.listingCategoryTypeId);

            if (result != null && result2 != null && result3 == null && result2.listingCategoryTypeId != 0)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }
    }
}

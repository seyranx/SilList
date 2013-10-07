using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class BusinessCategriesManagerTest
    {
        private BusinessCategoriesManager businessCategoriesManager = new BusinessCategoriesManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = businessCategoriesManager.getAll(null);

            if (res != null)
            {
                Assert.IsTrue(true);
            }
            else Assert.IsTrue(false);
        }

        [TestMethod]
        public void insertDeleteTest()
        {
            var vo = new BusinessCategoriesVo();
            vo.createdBy = 3;
            vo.modifiedBy = 4;
            // uncomenting next 2 lines leads to violation of FOREIGN KEY CONSTRAINTS
            //vo.businessCategoryTypeId = 7;
            //vo.businessId = new Guid();

            var result = businessCategoriesManager.insert(vo);
            var result2 = businessCategoriesManager.get(result.businessCategoryId);

            businessCategoriesManager.delete(result.businessCategoryId);

            var result3 = businessCategoriesManager.get(result.businessCategoryId);

            if (result != null && result2 != null && result3 == null && result2.businessCategoryId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }
    }
}

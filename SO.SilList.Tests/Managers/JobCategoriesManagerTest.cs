using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class JobCategriesManagerTest
    {
        private JobCategoriesManager jobCategoriesManager = new JobCategoriesManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = jobCategoriesManager.getAll(null);

            if (res != null)
            {
                Assert.IsTrue(true);
            }
            else Assert.IsTrue(false);
        }

        [TestMethod]
        public void insertDeleteTest()
        {
            var vo = new JobCategoriesVo();
            vo.createdBy = 3;
            vo.modifiedBy = 4;

            var result = jobCategoriesManager.insert(vo);
            var result2 = jobCategoriesManager.get(result.jobCategoriesId);

            jobCategoriesManager.delete(result.jobCategoriesId);

            var result3 = jobCategoriesManager.get(result.jobCategoriesId);

            if (result != null && result2 != null && result3 == null && result2.jobCategoriesId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

    }
}

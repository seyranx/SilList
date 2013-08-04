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
        private Guid? NULL;

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
            // uncomenting next 2 lines leads to violation of FOREIGN KEY CONSTRAINTS
            //vo.jobCategoryTypeId = 7;
            //vo.jobId = new Guid();

            var result = jobCategoriesManager.insert(vo);
            var result2 = jobCategoriesManager.get(result.jobCategoriesId);

            jobCategoriesManager.delete(result.jobCategoriesId);

            var result3 = jobCategoriesManager.get(result.jobCategoriesId);

            if (result != null && result2 != null && result3 == null )
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }
    }
}

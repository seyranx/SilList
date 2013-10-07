using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class JobTypeManagerTest
    {
        private JobTypeManager jobTypeManager = new JobTypeManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = jobTypeManager.getAll(null);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void insertRecordsTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                var vo = new JobTypeVo();
                vo.name = i.ToString() + ":  AAA Co" + "  >>";
                vo.description = i.ToString() + "A new Job Type" + "  >>";
                vo.createdBy = 11111;
                vo.modifiedBy = 11111;
                var result = jobTypeManager.insert(vo);
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
            var vo = new JobTypeVo();
            //vo.jobTypeId = 1;
            vo.name = "ABC Co";
            vo.description = "123 main st";
            vo.createdBy = 11111;
            vo.modifiedBy = 11111;

            var result = jobTypeManager.insert(vo);
            var result2 = jobTypeManager.get(result.jobTypeId);

            jobTypeManager.delete(result.jobTypeId);

            var result3 = jobTypeManager.get(result.jobTypeId);

            if (result != null && result2 != null && result3 == null && result2.jobTypeId != 0)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }
    }
}
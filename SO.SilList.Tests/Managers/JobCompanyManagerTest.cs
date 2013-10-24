using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class JobCompanyManagerTest
    {
        private JobCompanyManager jobCompanyManager = new JobCompanyManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = jobCompanyManager.getAll(null);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void insertRecordsTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                var vo = new JobCompanyVo();
                vo.name = i.ToString() + ":  AAA Co" + "  >>";
                vo.address = i.ToString() + "123 main st" + "  >>";
               
                vo.zip = 12345;
                vo.createdBy = 11111;
                vo.modifiedBy = 11111;
                var result = jobCompanyManager.insert(vo);
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
            var vo = new JobCompanyVo();
            vo.name = "ABC Co";
            vo.address = "123 main st";

            vo.zip = 12345;
            vo.createdBy = 11111;
            vo.modifiedBy = 11111;

            var result = jobCompanyManager.insert(vo);
            var result2 = jobCompanyManager.get(result.jobCompanyId);

            jobCompanyManager.delete(result.jobCompanyId);

            var result3 = jobCompanyManager.get(result.jobCompanyId);

            if (result != null && result2 != null && result3 == null && result2.jobCompanyId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }
    }
}


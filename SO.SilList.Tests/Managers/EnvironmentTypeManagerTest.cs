using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class EnvironmentTypeManagerTest{
    
        private EnvironmentTypeManager environmentType = new EnvironmentTypeManager();
        
        [TestMethod]
        public void getAllTest()
        {

            var res = environmentType.getAll(null);

            if (res != null)
            {
                Assert.IsTrue(true);
            }
            else Assert.IsTrue(false);
        }

                [TestMethod]
        public void insertRecordsTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                var vo = new EnvironmentTypeVo();
                vo.name = i.ToString() + " Test EnvironmentType Name ";
                var result = environmentType.insert(vo);
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
            var vo = new EnvironmentTypeVo();
            vo.name = "testName";
            
            var result = environmentType.insert(vo);
            var result2 = environmentType.get(result.environmentTypeId);

            environmentType.delete(result.environmentTypeId);

            var result3 = environmentType.get(result.environmentTypeId);

            if (result != null && result2 != null && result3 == null && result2.environmentTypeId != null )
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class TransmissionTypeManagerTest
    {
        private TransmissionTypeManager transmissionTypeManager = new TransmissionTypeManager();
        [TestMethod]
        public void getAllTest()
        {
            var res = transmissionTypeManager.getAll(null);

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
                var vo = new TransmissionTypeVo();
                vo.name = "BMW";
                //vo.name = i.ToString() + " Test BusinessCategoryType Name ";
                var result = transmissionTypeManager.insert(vo);
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
            var vo = new TransmissionTypeVo();
            vo.name = "test";


            var result = transmissionTypeManager.insert(vo);
            var result2 = transmissionTypeManager.get(result.transmissionTypeId);

            transmissionTypeManager.delete(result.transmissionTypeId);

            var result3 = transmissionTypeManager.get(result.transmissionTypeId);

            if (result != null && result2 != null && result3 == null && result2.transmissionTypeId != 0)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void includesTest()
        {

            var result = transmissionTypeManager.getFirst();

            //FK-s are disabled temporarily
            //var site = result.site;
            /*
                    if (result.site != null)
                    {
                        Assert.IsTrue(true);
                    }
                    else
                        Assert.IsTrue(false);
                    */

        }
    }
}

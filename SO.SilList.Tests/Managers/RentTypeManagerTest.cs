using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class RentTypeManagerTest
    {
        private StatusTypeManager rentTypeManager = new StatusTypeManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = rentTypeManager.getAll(null);

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
                var vo = new StatusTypeVo();
                vo.name = i.ToString() + " Test RentType Name ";
                vo.statusTypeId = i;
                var result = rentTypeManager.insert(vo);
                //TEST CHANGES
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
            var vo = new StatusTypeVo();
            vo.name = "testName";
            vo.description = "Test Description";

            var result = rentTypeManager.insert(vo);
            var result2 = rentTypeManager.get(result.statusTypeId);

            rentTypeManager.delete(result.statusTypeId);

            var result3 = rentTypeManager.get(result.statusTypeId);

            if (result != null && result2 != null && result3 == null && result2.statusTypeId != 0)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

        // FK-s are disabled temporarily
        //[TestMethod]
        //public void includesTest()
        //{

        //    var result = businessManager.getFirst();

        //    //FK-s are disabled temporarily
        //    //var site = result.site;

        //    if (result.site != null)
        //    {
        //        Assert.IsTrue(true);
        //    }
        //    else
        //        Assert.IsTrue(false);


        //}


    }
}

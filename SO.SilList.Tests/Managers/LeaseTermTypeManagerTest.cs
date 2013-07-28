using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
     [TestClass]
    class LeaseTermTypeManagerTest
    {
        private LeaseTermTypeManager leaseTermType = new LeaseTermTypeManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = leaseTermType.getAll(null);

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
                var vo = new LeaseTermTypeVo();
                vo.name = i.ToString() + " Test BusinessCategoryType Name ";
                var result = leaseTermType.insert(vo);
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
            var vo = new LeaseTermTypeVo();
            vo.name = "testName";
            

            var result = leaseTermType.insert(vo);
            var result2 = leaseTermType.get(result.leaseTermTypeId);

            leaseTermType.delete(result.leaseTermTypeId);

            var result3 = leaseTermType.get(result.leaseTermTypeId);

            if (result != null && result2 != null && result3 == null && result2.leaseTermTypeId != null)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void includesTest()
        {

            var result = leaseTermType.getFirst();

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

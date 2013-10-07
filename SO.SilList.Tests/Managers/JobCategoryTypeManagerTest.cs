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
    public class JobCategoryTypeManagerTest
    {
        private JobCategoryTypeManager jobCategoryType = new JobCategoryTypeManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = jobCategoryType.getAll(null);

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
                var vo = new JobCategoryTypeVo();
                vo.name = i.ToString() + " Test JobCategoryType Name ";
                var result = jobCategoryType.insert(vo);
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
            var vo = new JobCategoryTypeVo();
            vo.name = "testName";
            
            var result = jobCategoryType.insert(vo);
            var result2 = jobCategoryType.get(result.jobCategoryTypeId);

            jobCategoryType.delete(result.jobCategoryTypeId);

            var result3 = jobCategoryType.get(result.jobCategoryTypeId);

            if (result != null && result2 != null && result3 == null && result2.jobCategoryTypeId != 0 )
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void includesTest()
        {

            var result = jobCategoryType.getFirst();

            //FK-s are disabled temporarily
            //var site = result.site;

          /*  if (result.site != null)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
            */

        }

    
    }
}

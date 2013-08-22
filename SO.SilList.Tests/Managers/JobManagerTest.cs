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
    public class JobManagerTest
    {
        private JobManager jobManager = new JobManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = jobManager.getAll(null);

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
                var vo = new JobVo();
                vo.city = i.ToString()+"Test";
                vo.siteId = 1;
                var result = jobManager.insert(vo);
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
            var vo = new JobVo();
           vo.city = "testcity";
           vo.description = "124 address";

            var result = jobManager.insert(vo);
            var result2 = jobManager.get(result.jobId);

            jobManager.delete(result.jobId);

            var result3 = jobManager.get(result.jobId);

            if (result != null && result2 != null && result3 == null && result2.jobId != Guid.Empty)
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


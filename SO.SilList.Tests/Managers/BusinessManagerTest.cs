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
    public class BusinessManagerTest
    {
        private BusinessManager businessManager = new BusinessManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = businessManager.getAll(null);

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
                var vo = new BusinessVo();
                vo.name = i.ToString()+" Test Business Name ";
                vo.siteId = 1;
                var result = businessManager.insert(vo);
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
            var vo = new BusinessVo();
            vo.name = "testName";
            vo.address = "124 address";

            var result = businessManager.insert(vo);
            var result2 = businessManager.get(result.businessId);

            businessManager.delete(result.businessId);

            var result3 = businessManager.get(result.businessId);

            if (result != null && result2 != null && result3 == null && result2.businessId!=Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

         [TestMethod]
         public void includesTest()
         {
    
             var result= businessManager.getFirst();

             //FK-s are disabled temporarily
             //var site = result.site;

             if (result.site!=null)
             {
                 Assert.IsTrue(true);
             }
             else
                 Assert.IsTrue(false);


         }


        
         
    }
}

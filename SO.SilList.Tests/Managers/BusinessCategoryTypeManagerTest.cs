using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class BusinessCategoryTypeManagerTest
    {
        private BusinessCategoryTypeManager businessCategoryType = new BusinessCategoryTypeManager();

        [TestMethod]
        public void searchTest()
        {
            var vo = new BusinessCategoryTypeVm();
            vo.pageNumber = 2;
            vo.keyword = "aa";
            vo.isActive = true;

            var res = businessCategoryType.search(vo);

            if (res != null)
            {
                Assert.IsTrue(true);
            }
            else Assert.IsTrue(false);
        }

        [TestMethod]
        public void getAllTest()
        {

            var res = businessCategoryType.getAll(null);

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
                var vo = new BusinessCategoryTypeVo();
                vo.name = i.ToString() + " Test BusinessCategoryType Name ";
                var result = businessCategoryType.insert(vo);
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
            var vo = new BusinessCategoryTypeVo();
            vo.name = "testName";
            
            var result = businessCategoryType.insert(vo);
            var result2 = businessCategoryType.get(result.businessCategoryTypeId);

            businessCategoryType.delete(result.businessCategoryTypeId);

            var result3 = businessCategoryType.get(result.businessCategoryTypeId);

            if (result != null && result2 != null && result3 == null && result2.businessCategoryTypeId != null )
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void includesTest()
        {

            var result = businessCategoryType.getFirst();

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

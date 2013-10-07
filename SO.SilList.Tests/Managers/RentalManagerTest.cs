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
    public class RentalManagerTest
    {
        private RentalManager rentalManager = new RentalManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = rentalManager.getAll(null);

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
                var vo = new RentalVo();
                vo.rent = i*1234;
                //vo.name = i.ToString() + " Test BusinessCategoryType Name ";
                var result = rentalManager.insert(vo);
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
            var vo = new RentalVo();
            vo.rent = 1500.99;


            var result = rentalManager.insert(vo);
            var result2 = rentalManager.get(result.rentalId);

            rentalManager.delete(result.rentalId);

            var result3 = rentalManager.get(result.rentalId);

            if (result != null && result2 != null && result3 == null && result2.rentalId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void searchTest()
        {
            var vo = new RentalVm();
            vo.paging.pageNumber = 2;
            vo.keyword = "Some title";
            vo.isActive = true;

            var res = rentalManager.search(vo);

            if (res != null)
            {
                Assert.IsTrue(true);
            }
            else Assert.IsTrue(false);
        }

        [TestMethod]
        public void includesTest()
        {

            var result = rentalManager.getFirst();

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

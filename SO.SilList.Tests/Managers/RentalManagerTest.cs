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
    public class RentalManagerTest
    {
        private RentalsManager Rental = new RentalsManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = Rental.getAll(null);

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
                var vo = new RentalsVo();
                vo.rent = i*1234;
                //vo.name = i.ToString() + " Test BusinessCategoryType Name ";
                var result = Rental.insert(vo);
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
            var vo = new RentalsVo();
            vo.rent = 1500.99;


            var result = Rental.insert(vo);
            var result2 = Rental.get(result.rentalId);

            Rental.delete(result.rentalId);

            var result3 = Rental.get(result.rentalId);

            if (result != null && result2 != null && result3 == null && result2.rentalId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void includesTest()
        {

            var result = Rental.getFirst();

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

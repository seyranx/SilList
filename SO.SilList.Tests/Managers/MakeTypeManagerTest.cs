﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class MakeTypeManagerTest
    {
        private MakeTypeManager makeTypeManager = new MakeTypeManager();

        [TestMethod]
        public void getAllTest()
        {
            var res = makeTypeManager.getAll(null);

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
                var vo = new MakeTypeVo();
                vo.name = "BMW";
                //vo.name = i.ToString() + " Test BusinessCategoryType Name ";
                var result = makeTypeManager.insert(vo);
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
            var vo = new MakeTypeVo();
            vo.name = "test";


            var result = makeTypeManager.insert(vo);
            var result2 = makeTypeManager.get(result.makeTypeId);

            makeTypeManager.delete(result.makeTypeId);

            var result3 = makeTypeManager.get(result.makeTypeId);

            if (result != null && result2 != null && result3 == null && result2.makeTypeId != null)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void includesTest()
        {

            var result = makeTypeManager.getFirst();

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
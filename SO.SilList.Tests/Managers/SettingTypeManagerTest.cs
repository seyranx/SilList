using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class SettingTypeManagerTest
    {

        private SettingTypeManager settingType = new SettingTypeManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = settingType.getAll(null);

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
                var vo = new SettingTypeVo();
                vo.name = i.ToString() + " Test SettingTypeManager Name ";
                vo.groupName = "Test GroupName";
                var result = settingType.insert(vo);
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
            var vo = new SettingTypeVo();
            vo.name = "testName";
            vo.groupName = "Test GroupName";

            var result = settingType.insert(vo);
            var result2 = settingType.get(result.settingTypeId);

            settingType.delete(result.settingTypeId);

            var result3 = settingType.get(result.settingTypeId);

            if (result != null && result2 != null && result3 == null && result2.settingTypeId != null)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }



    }
}

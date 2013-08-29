using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class VisitManagerTest
    {
        private VisitManager visitManager = new VisitManager();
        private Random r = new Random();

        [TestMethod]
        public void searchTest()
        {
            var vo = new VisitVm();
            vo.pageNumber = 2;
            vo.keyword = "Home";

            var result = visitManager.search(vo);
            
            Assert.IsTrue(0 != result);            
        }
        
        
        [TestMethod]
        public void fillDb()
        {

            using (var db = new MainDb())
            {

                // get a valid site id
                var site = db.sites.FirstOrDefault();
                Assert.IsTrue(null != site);
                
                // add some visits
                for (int i = 1; i < 100; i++)
                {
                    var visit = new VisitVo();
                    visit.siteId = site.siteId;
                    visit.ipAddress = getRandomIp();
                    visit.referrerUrl = getRandomReferrer();
                    visit.visitTime = getRandomDate();
                    visit.browser = getRandomBrowser();
                    visit.controller = getRandomController();
                    visit.action = getRandomAction();

                    try
                    {
                        db.visits.Add(visit);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }

        public string getRandomReferrer()
        {
            string[] list = {
                "google.com"
                , "yahoo.com"
                , "msn.com"
                , "apple.com"
                , "facebook.com"
                            };

            return list[this.r.Next(0, list.Length - 1)];
        }

        public DateTime getRandomDate()
        {
            return new DateTime(r.Next(2012, 2013), r.Next(1, 12), r.Next(1, 30), r.Next(0, 23), r.Next(0, 59), r.Next(0, 59));
        }

        public string getRandomIp()
        {
            string ip = "";
            for (int i = 1; i <= 4; i++)
            {
                ip += this.r.Next(0, 255).ToString();
                if (i != 4)
                    ip += ".";
            }

            return ip;
        }

        public string getRandomBrowser()
        {
            string[] list = {
                "IE 6"
                , "IE 7"
                , "IE 8"
                , "IE 9"
                , "IE 10"
                , "IE 11"
                , "Google Chrome 28"
                , "Google Chrome 29"
                , "Firefox 21"
                , "Firefox 22"
                , "Firefox 23"
                            };

            return list[this.r.Next(0, list.Length - 1)];
        }

        public string getRandomController()
        {
            string[] list = {
                "Account"
                , "Admin"
                , "Business"
                , "Car"
                , "Environment"
                , "Home"
                , "Image"
                , "Job"
                , "Linked"
                , "Listing"
                , "Rentals"
                            };

            return list[this.r.Next(0, list.Length - 1)];
        }

        public string getRandomAction()
        {
            string[] list = {
                "Index"
                , "Create"
                , "Delete"
                , "Update"
                , "List"
                            };

            return list[this.r.Next(0, list.Length - 1)];
        }
    }
}

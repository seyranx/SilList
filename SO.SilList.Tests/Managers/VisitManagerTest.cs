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
        private SiteManager siteManager = new SiteManager();
        private Random r = new Random();

        [TestMethod]
        public void searchTest()
        {
            var vo = new VisitVm();
            vo.paging.pageNumber = 2;
            vo.keyword = "Home";

            var resultVm = visitManager.search(vo);

            Assert.IsTrue(0 != resultVm.result.Count);            
        }
        
        
        [TestMethod]
        public void fillDb()
        {

            using (var db = new MainDb())
            {
                // add some visits
                for (int i = 0; i < 100; i++)
                {
                    var visit = new VisitVo();
                    visit.siteId = getRandomSite();
                    visit.ipAddress = getRandomIp();
                    visit.referrerUrl = getRandomReferrer();
                    visit.created = getRandomDate();
                    visit.modified = visit.created.AddMinutes(r.Next(1, 60*24));
                    visit.browser = getRandomBrowser();
                    visit.controller = getRandomController();
                    visit.action = getRandomAction();
                    visit.visitCount = r.Next(1, 10);

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

        public int getRandomSite()
        {
            var sites = siteManager.getAll();

            return sites[r.Next(0, sites.Count)].siteId;
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

            return list[this.r.Next(0, list.Length)];
        }

        public DateTime getRandomDate()
        {
            return new DateTime(r.Next(2012, 2014), r.Next(1, 13), r.Next(1, 31), r.Next(0, 24), r.Next(0, 60), r.Next(0, 60));
        }

        public string getRandomIp()
        {
            string ip = "";
            for (int i = 1; i <= 4; i++)
            {
                ip += this.r.Next(0, 256).ToString();
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

            return list[this.r.Next(0, list.Length)];
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

            return list[this.r.Next(0, list.Length)];
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

            return list[this.r.Next(0, list.Length)];
        }
    }
}

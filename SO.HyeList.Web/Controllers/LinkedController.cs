using FileHelpers;
using SO.HyeList.Manager.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.HyeList.Web.Controllers
{
    public class LinkedController : Controller
    {
   
        public ActionResult ShowNew()
        {

            if (Request.Files.Count > 1)
            {

                var oldExport = Request.Files["oldExport"];
                var newExport = Request.Files["newExport"];

                string dir = @"C:\WINDOWS\Temp\linkedInExport\";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string oldExportFileName = dir + Guid.NewGuid().ToString() + ".csv";
                string newExportFileName = dir + Guid.NewGuid().ToString() + ".csv";

                oldExport.SaveAs(oldExportFileName);
                newExport.SaveAs(newExportFileName);

                var result = getNewConnections(oldExportFileName, newExportFileName);

                return View(result);

            }

            return View();
        }


        private List<Connection> getNewConnections(string oldExportFileName, string newExportFileName)
        {

            var oldConnections = getConnections(oldExportFileName);
            var newConnections = getConnections(newExportFileName);

            var oldEmails = oldConnections.Select(o => o.email).ToList();

            //var final2 = newConnections.Except(oldConnections).ToList();
            var final = newConnections.Where(c => !oldEmails.Contains(c.email)
                                            && (c.lastName.ToLower().Contains("ian") || c.lastName.ToLower().Contains("yan")))
                                            .ToList();
            return final;
        }

        private List<Connection> getConnections(string csvFileName)
        {


            if (!System.IO.File.Exists(csvFileName))
                throw new Exception("File not found: " + csvFileName);

            var result = CommonEngine.ReadCsv(csvFileName, ',').ToList();

            var connections = new List<Connection>();

            if (result != null && result.Count() > 0)
            {

                foreach (var item in result)
                {

                    if (item.Count() < 5) continue;

                    var conn = new Connection();
                    conn.firstName = item[1];
                    conn.lastName = item[3];
                    conn.email = item[5];
                    connections.Add(conn);
                }

            }

            return connections;
        }

    }
}

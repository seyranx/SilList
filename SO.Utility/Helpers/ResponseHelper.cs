using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace SO.Utility.Helpers
{
    public class ResponseHelper
    {

        public static void showFile(string filename, bool? showDialog)
        {

            FileInfo file = new FileInfo(filename);
            if (file.Exists) 
            {
                var response = HttpContext.Current.Response;
                response.Clear();

                // this embeds file in browser instead of open/save dialog. 
                if (showDialog == true)
                    response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);

                response.AddHeader("Content-Length", file.Length.ToString());
                response.ContentType = ImportExportHelper.getContentType(file.Extension);

                file.IsReadOnly = true;
                response.WriteFile(file.FullName);
                response.End();
            }

        }

       


        public static void showImage(object BinaryData, string ContentType, bool ShowThumbnail)
        {

            byte[] byteImage = (byte[])BinaryData;

            if (ShowThumbnail)
            {
                byteImage = ImageHelper.GetImageThunbnail(byteImage, ContentType);
            }
            HttpResponse Response = Common.GetCurrentResponse;
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = ContentType;
            Response.BinaryWrite(byteImage);
            Response.End();

        }



    }
}

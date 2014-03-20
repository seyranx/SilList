using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Web;

namespace SO.Utility.Helpers
{
    public class ImageHelper
    {

        public static Byte[] ResizeImage(Image image, int NewMaxHeight, int NewMaxWidth, ref string ContentType)
        {
            byte[] imageContent = null;

            try
            {
                // We want to preserve the height to width ratio.
                int iCurrentHeight = image.Height;
                int iCurrentWidth = image.Width;
                decimal Ratio = iCurrentHeight / Convert.ToDecimal(iCurrentWidth);

                // If the image is already smaller than what was asked for (via NewMaxHeight and 
                // NewMaxWidth) in one or more dimensions, then we won't touch those dimensions.
                bool DoResizeHeight = (iCurrentHeight > NewMaxHeight);
                bool DoResizeWidth = (iCurrentWidth > NewMaxWidth);

                if (DoResizeHeight && DoResizeWidth)
                {
                    if (iCurrentHeight > iCurrentWidth)
                    {
                        NewMaxWidth = Convert.ToInt32(NewMaxHeight / Ratio);
                    }
                    else
                    {
                        NewMaxHeight = Convert.ToInt32(NewMaxWidth * Ratio);
                    }
                }
                else if (DoResizeHeight)		// We'll use the NewMaxHeight for the new height, and we'll calc the NewMaxWidth according to the original ratio.
                {
                    NewMaxWidth = Convert.ToInt32(NewMaxHeight / Ratio);
                }
                else if (DoResizeWidth)		// We'll use the NewMaxWidth for the new width, and we'll calc the NewMaxHeight according to the original ratio.
                {
                    NewMaxHeight = Convert.ToInt32(NewMaxWidth * Ratio);
                }
                else								// No resizing is needed!
                {
                    NewMaxWidth = iCurrentWidth;
                    NewMaxHeight = iCurrentHeight;
                }
                MemoryStream msImage = new MemoryStream();
                Image imgNew = null;


                imgNew = new Bitmap(image, NewMaxWidth, NewMaxHeight);
                imgNew.Save(msImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                ContentType = "image/jpeg";

                imageContent = new Byte[msImage.Length];
                msImage.Position = 0;
                msImage.Read(imageContent, 0, (int)msImage.Length);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return imageContent;
        }


        public static Byte[] GetByteArray(Image img)
        {
            MemoryStream msImage = new MemoryStream();

            img.Save(msImage, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] imageArray = new Byte[msImage.Length];
            msImage.Position = 0;
            msImage.Read(imageArray, 0, (int)msImage.Length - 1);

            return imageArray;

        }

        public static Byte[] GetByteArray(HttpPostedFile postedFile)
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(postedFile.InputStream);

            return GetByteArray(image);
        }

      
      



        public static bool IsImageFormat(string ContentType)
        {
            bool iReturn = false;
            switch (ContentType.ToLower())
            {
                case "image/jpeg":
                case "image/pjpeg":
                case "image/bmp":
                case "image/gif":
                case "image/x-png":
                    iReturn = true;
                    break;
            }
            return iReturn;
        }


        public static byte[] GetImageThunbnail(byte[] byteImage, string ContentType)
        {
            return GetImageThunbnail(byteImage, ContentType, 150, 150);

        }
        public static byte[] GetImageThunbnail(byte[] byteImage, string ContentType, int NewMaxHeight, int NewMaxWidth)
        {
            
                MemoryStream stream = new MemoryStream();
                stream.Write(byteImage, 0, byteImage.Length);
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                byteImage = ResizeImage(img, NewMaxHeight, NewMaxWidth, ref ContentType);
                return byteImage;
        }
       

    }
}

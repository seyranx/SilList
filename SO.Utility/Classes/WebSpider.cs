using SO.Utility.Enums;
using SO.Utility.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SO.Utility.Classes
{
    public class WebSpider
    {
        public CookieContainer coCookies = new CookieContainer();

        public WebSpider()
        {
          
        }

       public string getResponse(string url, HttpRequestMethod method = HttpRequestMethod.GET, Dictionary<string,string> postData=null, CookieContainer cookies=null)
       {
         
        
            string result = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.AllowAutoRedirect = true;
            httpWebRequest.AllowWriteStreamBuffering = true;
            httpWebRequest.KeepAlive = true;
            httpWebRequest.Method = method.ToString();

           if(cookies!=null)
            httpWebRequest.CookieContainer = cookies;

           if (method == HttpRequestMethod.POST)
            {
                string queryString = QueryStringHelper.toQueryString(postData);
                byte[] b = System.Text.Encoding.ASCII.GetBytes(queryString);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.ContentLength = (long)b.Length;
                Stream httpStream = httpWebRequest.GetRequestStream();
                httpStream.Write(b, 0, b.Length);
                httpStream.Close();

            }

            var objResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            return result;

        }

        /*
        public string getResponse2(string url, HttpRequestMethod method = HttpRequestMethod.GET, Dictionary<string,string> postData=null)
        {
            CookieContainer myCookie = new CookieContainer();

            string AuctionUrl = "";

            HttpWebRequest HttpRequest;


            HttpRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpRequest.AllowAutoRedirect = true;

            HttpRequest.ProtocolVersion = HttpVersion.Version10;
            HttpRequest.CookieContainer = myCookie;
            HttpRequest.KeepAlive = false;

            HttpWebResponse HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();
            myCookie.Add(HttpResponse.Cookies);

            StreamReader HttpStreamReader = new StreamReader(HttpResponse.GetResponseStream());
            string strResponse = HttpStreamReader.ReadToEnd();
            HttpStreamReader.Close();

            HttpRequest = (HttpWebRequest)WebRequest.Create(AuctionUrl);
           
          
           
            HttpRequest.AllowAutoRedirect = true;
            HttpRequest.KeepAlive = true;
            HttpRequest.ProtocolVersion = System.Net.HttpVersion.Version10;

            HttpRequest.Method = method.ToString();

            if (method == HttpRequestMethod.POST)
            {
                string queryString = QueryStringHelper.toQueryString(postData);
                byte[] b = System.Text.Encoding.ASCII.GetBytes(queryString);
                HttpRequest.ContentType = "application/x-www-form-urlencoded";
                HttpRequest.ContentLength = (long)b.Length;
                Stream HttpStream = HttpRequest.GetRequestStream();
                HttpStream.Write(b, 0, b.Length);
                HttpStream.Close();

            }

            HttpRequest.CookieContainer = myCookie;


            HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();

            StreamReader HttpStreamReader2 = new StreamReader(HttpResponse.GetResponseStream());
            strResponse = HttpStreamReader2.ReadToEnd();
            HttpStreamReader2.Close();


            HttpRequest = (HttpWebRequest)WebRequest.Create(AuctionUrl);
            HttpRequest.AllowAutoRedirect = true;
            HttpRequest.ProtocolVersion = HttpVersion.Version10;

            HttpRequest.CookieContainer = myCookie;
            HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();
            // RedirectUrl = HttpResponse.ResponseUri.AbsoluteUri;
            HttpStreamReader = new StreamReader(HttpResponse.GetResponseStream());
            strResponse = HttpStreamReader.ReadToEnd();
            HttpStreamReader.Close();




            return myCookie;
            //return strResponse;






        }
        
         */

    }
}

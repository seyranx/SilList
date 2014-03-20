using HtmlAgilityPack;
using SO.Utility.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.Utility.Helpers
{
    public static class HtmlHelper
    {

        public static List<LinkVo> getLinks(string htmlSource = null, string htmlFile = null)
        {

            var list = new List<LinkVo>();
            HtmlDocument doc = new HtmlDocument();
            if (htmlFile != null)
                doc.Load(htmlFile);
            else
                doc.LoadHtml(htmlSource);

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a"))
            {
                var value = node.GetAttributeValue("href", null);
                list.Add(new LinkVo(node.InnerText, value));
            }

            return list;
        }
    }
}

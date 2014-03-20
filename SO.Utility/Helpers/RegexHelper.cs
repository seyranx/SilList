using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SO.Utility.Helpers
{
  public  class RegexHelper
    {

      /// <summary>
      /// replace all characters other than letters/numbers with empty string
      /// </summary>
      public static string getAlphanumeric(string str)
      {
         
          str = Regex.Replace(str, @"[^A-Za-z0-9]+", String.Empty);
          return str;
      }

      

      public static List<string> getLinks(string data)
      {

          return getMatches(data, @"((mailto\:|(news|(ht|f)tp(s?))\://){1}\S+)");
      }

      public static List<string> getEmailAddresses(string data)
      {

          return getMatches(data, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
      }


      public static List<string> getMatches(string data, string regex)
      {
          //instantiate with this pattern 
          Regex dataRegex = new Regex(@regex, RegexOptions.IgnoreCase);
          //find items that matches with our pattern
          MatchCollection dataMatches = dataRegex.Matches(data);

          var list = new List<string>();
          if (dataMatches == null || dataMatches.Count == 0) return null;
          var sb = new StringBuilder();
          foreach (Match dataMatch in dataMatches)
          {
              //dataMatch.Groups
              list.Add(dataMatch.Value);
          }
          return list;
      }

    }
}

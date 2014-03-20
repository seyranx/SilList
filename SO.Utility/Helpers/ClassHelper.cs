using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using SO.Utility.Extensions;

namespace SO.Utility.Helpers
{
   public static class ClassHelper
    {

       public static Dictionary<string, object> getPropertiesWithValues(object obj)
        {
            var result = new Dictionary<string, object>();
          
            foreach (PropertyInfo p in obj.GetType().GetProperties())
            {
                result.Add(p.Name, p.GetValue(obj, null));
            }
            var rone = result.getValue("one");
            return result;
        }

        public static List<object> getValues(object obj)
        {
            var result = new List<object>();
            foreach (PropertyInfo p in obj.GetType().GetProperties())
            {
                result.Add(p.GetValue(obj, null));
            }
            return result;
        }


        #region getProperties

        public static List<string> getProperties(List<object> list)
        {
            if (list == null || list.Count()==0) return null;
            var first = list.FirstOrDefault();
            return getProperties(first);
        }

        public static List<string> getProperties(object obj)
        {
            if (obj == null) return null;
            return getProperties(obj.GetType());
        }

        public static List<string> getProperties(Type type)
        {
            var result = new List<string> ();
            foreach (PropertyInfo p in type.GetProperties())
            {
                result.Add(p.Name);
            }
            return result;
        }

        #endregion 

        public static object getProperty(object obj, string propertyName)
        {
            try
            {
                return obj.GetType().GetProperty(propertyName);
            }
            catch { return null; }
        }

        public static void SetProperties(object obj, Hashtable data)
        {
          
            foreach (FieldInfo f in obj.GetType().GetFields())
            {
                if (!data.ContainsKey(f.Name) || String.IsNullOrEmpty(data[f.Name].ToString()))
                    f.SetValue(obj, null);
                else if (f.FieldType == typeof(String)) 
                    f.SetValue(obj, data[f.Name].ToString());
                else 
                    f.SetValue(obj, data[f.Name]);
            }

            ArrayList props = null; // GetPropertiesArrayList(obj);

            foreach (PropertyInfo p in props)
            {
                if (!data.ContainsKey(p.Name))
                    p.SetValue(obj, null, null);
                else
                    p.SetValue(obj, data[p.Name], null);
            }
         
        }

     

    }
}

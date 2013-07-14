using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.HyeList.Manager.Classes
{
    public class Connection
    {
        // Must specify FieldOrder too

        public string name
        {
            get { return firstName + " " + lastName; }
        }


        public string firstName { get; set; }


        public string lastName { get; set; }


        public string email { get; set; }
    }
}

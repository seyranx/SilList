using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.Utility.Classes.Email
{
    public class EmailVo
    {
        public string fromName { get; set; }
        public string toEmail { get; set; }
        public string fromEmail { get; set; }
        
        public string subject { get; set; }
        public string body { get; set; }
         

        public EmailVo()
        {
            
        }
    }
}

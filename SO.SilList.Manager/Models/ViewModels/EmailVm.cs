using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace SO.SilList.Manager.Models.ViewModels
{
    

    public class EmailVm
    {
        public string sender { get; set; }
        public string sendTo { get; set; }
        public string cc { get; set; }
        public string subject { get; set; }
        public string header { get; set; }
        public string body { get; set; }
        public string footer { get; set; }
        public string attachment { get; set; }
        public bool confirmation { get; set; }
        public string thankYouNote { get; set; }
        
        public string redirectTo { get; set; }
       
        public bool valid()
        {
            if (sender == null || sender.Trim() == "" || sendTo == null || sendTo.Trim() == "" )
                return false;
            return true;
        }
        public string getFullBody()
        {
            string fullbody = header + System.Environment.NewLine;
            fullbody += body + System.Environment.NewLine;
            fullbody += footer;
            
            return fullbody;
        }
        public EmailVm()
        {
            footer = "HyeList Copyright 2013   www.hyelist.com ";
            thankYouNote = "Thank you for being part of HyeList community." + System.Environment.NewLine;
            thankYouNote += "Your Email has been succesfully sent!" + System.Environment.NewLine;
            confirmation = false;
        }
    }
}

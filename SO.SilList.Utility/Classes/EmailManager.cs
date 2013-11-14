
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SO.SilList.Utility.Classes
{
    public class EmailManager
    {
        public void sendMail(string from, string to, string subject, string body)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add(to);
            message.Subject = subject;
            message.From = new System.Net.Mail.MailAddress(from, from);
            message.ReplyToList.Add(from);
            message.Body = body;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential("sender@silverobject.com", "office575757");
            smtp.Port = 25;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = theCredential;
            smtp.Send(message);
            

        }
    }
}
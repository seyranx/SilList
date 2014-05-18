using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SO.Utility.Classes.Email
{
    public class EmailSender
    {

        private SmtpClient smtpClient;

        public EmailSender(string accountEmail = null, string password = null, string host = null)
        {
            smtpClient = new SmtpClient();

            if (accountEmail != null && password != null)
                this.setCredentials(accountEmail, password, host);

        }


        public bool send(string fromName, string toEmail, string subject, string body, string fromEmail = null)
        {
            var vo = new EmailVo();
            vo.fromName = fromName;
            vo.subject = subject;
            vo.toEmail = toEmail;
            vo.body = body;
            vo.fromEmail = fromEmail;
 
            return send(vo);
        }

        public bool send(EmailVo email)
        {

            MailMessage message = new MailMessage();

              var nc = (NetworkCredential)smtpClient.Credentials;

              if (string.IsNullOrEmpty(email.fromEmail))
                  email.fromEmail = nc.UserName;

              message.IsBodyHtml = true;
              message.Subject = email.subject;

              message.Body = email.body;

            message.BodyEncoding = Encoding.GetEncoding("Windows-1252");

            message.From = new MailAddress(email.fromEmail, email.fromName);
            message.ReplyToList.Add(new MailAddress(email.fromEmail, email.fromName));

            message.To.Add(new MailAddress(email.toEmail));

            smtpClient.EnableSsl = true;

            smtpClient.Send(message);

            return true;
        }

        public void setCredentials(string email, string password, string host = null)
        {
            if (string.IsNullOrEmpty(host))
                host = "smtp.gmail.com";
            smtpClient.Host = host;
            smtpClient.Credentials = new NetworkCredential(email, password);
        }
    }
}

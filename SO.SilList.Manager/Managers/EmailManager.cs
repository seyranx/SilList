
using SO.SilList.Manager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace SO.SilList.Manager.Managers
{
    public class EmailManager
    {
        public string username {get;set;}
        public string password { get; set; }
        public string host { get; set; }

        public EmailManager()
        {
            username = "sender@silverobject.com";
            password = "office575757";
            host = "smtp.gmail.com";
        }
        public EmailManager(string _username, string _password, string _host)
        {
            username = _username;
            password = _password;
            host = _host;
        }
        public bool sendMail(EmailVm input)
        {
            if (input.valid())
            {
                Attachment attachment = null;
                if (input.attachment != null)
                {

                    
                    attachment = new Attachment(input.attachment, MediaTypeNames.Application.Octet);
                    ContentDisposition disposition = attachment.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(input.attachment);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(input.attachment);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(input.attachment);
                    
                }
                sendMail(input.sender, input.sendTo, input.subject, input.getFullBody(), input.cc, attachment);
                
                if(input.confirmation)
                {
                    string subject ="Email Confirmation for "+input.subject;
                    string body = input.thankYouNote;
                    body += System.Environment.NewLine + "Copy of your email." + System.Environment.NewLine;
                    body += "-----------------------------------------------------------------------------" + System.Environment.NewLine;
                    body += input.getFullBody();

                    sendMail(username, input.sender, subject, body,null,attachment);
                }
                return true;
            }
            return false;
        }
        public void sendMail(string from, string to, string subject, string body, string cc=null,System.Net.Mail.Attachment attachment = null)
        {
            if (from == null || to == null)
                return;
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add(to);
            if (cc!= null)
            {
                message.To.Add(cc);
            }
            message.Subject = subject;
            message.From = new System.Net.Mail.MailAddress(from, from);
            message.ReplyToList.Add(from);
            message.Body = body;
            if (attachment != null)
                message.Attachments.Add(attachment);
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(username,password);
            smtp.Port = 25;
            smtp.Host = host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = theCredential;
            smtp.Send(message);
        }
    }
}
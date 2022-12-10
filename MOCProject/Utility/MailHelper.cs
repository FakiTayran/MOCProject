using Microsoft.AspNetCore.Identity;
using MOCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MOCProject.Utility
{
    public static class MailHelper
    {
        public static void MailSender(string Subject,List<string> To, string Body, MailPriority mailPriority)
        {
            #region Mail Gönder
            MailMessage msg = new MailMessage();
            msg.Subject = Subject;
            msg.From = new MailAddress("ariduru@gmail.com", "Moc Company");
            foreach (var mail in To)
            {
                msg.To.Add(mail);
            }
            msg.Body = Body;
            msg.Priority = mailPriority;
            #region Host ve Port
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            #endregion
            //Setup credentials to login to our sender email address ("UserName", "Password")
            NetworkCredential credentials = new NetworkCredential("ariduru@gmail.com", "*");

            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            client.Send(msg);
            #endregion
        }
    }
}

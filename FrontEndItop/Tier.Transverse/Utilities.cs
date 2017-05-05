using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Transverse
{
    public class Utilities
    {
        public static string GetStringFromBase64(string base64String)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64String));
        }

        public static bool SendMail(string recipients, string subject, string body)
        {
            try
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

                var smtpSection = (System.Net.Configuration.SmtpSection)System.Configuration.ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                string username = smtpSection.Network.UserName;

                subject = System.Configuration.ConfigurationManager.AppSettings["ApplicationName"] + " - " + subject;

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

                mail.Body = body;
                mail.From = new System.Net.Mail.MailAddress(username);
                mail.Subject = subject;

                foreach (string item in recipients.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    mail.To.Add(item);
                }

                mail.IsBodyHtml = true;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnFailure;

                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using ScHackathon.Feature.Notification.Extensions;
using ScHackathon.Feature.Notification.Interfaces;
using Sitecore.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using EmailArgs = ScHackathon.Feature.Notification.ScHackthonSettings;

namespace ScHackathon.Feature.Notification.Services
{
    /// <summary>
    /// Handles notifications on news letter subscription
    /// </summary>
    public class NotificationService : INotificationService
    {
        private readonly Database _db;
        private string _contactId;
        private string _emailId;
        private string _settingsPath;

        public NotificationService()
        {
            _db = Sitecore.Context.Database.Name.Equals("core", System.StringComparison.InvariantCultureIgnoreCase) ?
                    Sitecore.Configuration.Factory.GetDatabase("master") : Sitecore.Context.Database;
        }

        public INotificationService Setup(string cid, string emailId, string settingsPath)
        {
            _contactId = cid;
            _emailId = emailId;
            _settingsPath = settingsPath;
            return this;
        }

        /// <summary>
        /// Send email to subscriber
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public bool Send()
        {
            var subscriptionConfirmationSetting = _db.GetItem(_settingsPath);

            SmtpClient smtpClient = new SmtpClient()
            {
                Host = EmailArgs.SmtpHost,
                Port = EmailArgs.SmtpPort.IfEmpty(25),
                UseDefaultCredentials = EmailArgs.UseDefaultCredentials,
                Credentials = new NetworkCredential(EmailArgs.SmtpUserName, EmailArgs.SmtpPassword)
            };


            ServicePointManager.ServerCertificateValidationCallback =
                            delegate (object s, X509Certificate certificate, X509Chain chain,
                                     SslPolicyErrors sslPolicyErrors)
                            { return true; };

            if (subscriptionConfirmationSetting != null)
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(subscriptionConfirmationSetting[Templates.HtmlMessage.Fields.FromAddress], subscriptionConfirmationSetting[Templates.HtmlMessage.Fields.FromName]),
                    Subject = subscriptionConfirmationSetting[Templates.HtmlMessage.Fields.Subject],
                    IsBodyHtml = true,
                    Body = subscriptionConfirmationSetting[Templates.HtmlMessage.Fields.Body].ReplaceTokens(_contactId, _emailId)
                };

                mail.To.Add(_emailId);

                smtpClient.Send(mail);
                return true;
            }
            else
            {
                Sitecore.Diagnostics.Log.Error("Email Settings Item Doesn't Exists", this);
                return false;
            }
        }
    }
}

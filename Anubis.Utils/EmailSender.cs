using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Anubis.Utils.Properties;

namespace Anubis.Utils
{
    public class EmailSender
    {
        private readonly string smtpServer;
        private readonly int smtpPort;
        private readonly string smtpUsername;
        private readonly string smtpPassword;
        private readonly IEnumerable<Attachment> attachments;
        private readonly IEnumerable<LinkedResource> resources;

        public EmailSender(IEnumerable<Attachment> attachments = null, IEnumerable<LinkedResource> resources = null)
        {
            smtpUsername = Settings.Default.SmtpUser;
            smtpPassword = Settings.Default.SmtpPassword;
            smtpPort = Settings.Default.SmtpPort;
            smtpServer = Settings.Default.SmtpServer;

            From = Settings.Default.SupportEmail;
            FromAlias = Settings.Default.SupportAlias;
            IsBodyHtml = Settings.Default.SmtpIsBodyHtml;
            IsSecureConnection = Settings.Default.SmtpIsSecured;

            this.attachments = attachments;
            this.resources = resources;
        }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string FromAlias { get; set; }

        public string ToAlias { get; set; }

        public string CCEmail { get; set; }

        public bool IsSecureConnection { get; set; }

        public bool IsBodyHtml { get; set; }

        public void FireEmail()
        {
            var from = new MailAddress(From, FromAlias ?? From);
            var to = new MailAddress(To, ToAlias ?? To);

            using (var message = new MailMessage(from, to))
            {
                message.IsBodyHtml = IsBodyHtml;
                message.Subject = Subject;
                message.Body = Body;

                if (!string.IsNullOrWhiteSpace(CCEmail))
                {
                    message.CC.Add(new MailAddress(CCEmail));
                }

                if (attachments != null)
                {
                    foreach (var attachment in attachments)
                    {
                        message.Attachments.Add(attachment);
                    }
                }

                if (resources != null)
                {
                    using (var av = AlternateView.CreateAlternateViewFromString(message.Body))
                    {
                        if (message.IsBodyHtml)
                        {
                            av.ContentType = new ContentType("text/html");
                        }

                        foreach (var resource in resources)
                        {
                            av.LinkedResources.Add(resource);
                        }

                        message.AlternateViews.Add(av);

                        Delivery(message);
                    }
                }

                Delivery(message);
            }
        }

        public void FireEmail(string toEmail, string toAlias, string subject, string body)
        {
            ToAlias = toAlias;
            To = toEmail;
            Subject = subject;
            Body = body;

            FireEmail();
        }

        private void Delivery(MailMessage message)
        {
            using (var client = new SmtpClient(smtpServer))
            {
                client.Port = smtpPort;
                client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                client.EnableSsl = IsSecureConnection;
                client.Send(message);
            }
        }
    }
}
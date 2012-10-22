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

        public EmailSender()
        {
            smtpUsername = Settings.Default.SmtpUser;
            smtpPassword = Settings.Default.SmtpPassword;
            smtpPort = Settings.Default.SmtpPort;
            smtpServer = Settings.Default.SmtpServer;

            From = Settings.Default.SupportEmail;
            FromAlias = Settings.Default.SupportAlias;
            IsBodyHtml = Settings.Default.SmtpIsBodyHtml;
            IsSecureConnection = Settings.Default.SmtpIsSecured;
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

        public IList<Attachment> Attachments { get; set; }

        public IList<LinkedResource> Resources { get; set; }

        public void FireEmail()
        {
            var from = new MailAddress(From, FromAlias ?? From);
            var to = new MailAddress(To, ToAlias ?? To);

            var message = new MailMessage(from, to)
            {
                IsBodyHtml = IsBodyHtml,
                Subject = Subject,
                Body = Body,
            };

            if (!string.IsNullOrWhiteSpace(CCEmail))
            {
                message.CC.Add(new MailAddress(CCEmail));
            }

            if (Attachments != null)
            {
                foreach (var attachment in Attachments)
                {
                    message.Attachments.Add(attachment);
                }
            }

            if (Resources != null)
            {
                var av = AlternateView.CreateAlternateViewFromString(message.Body);
                if (message.IsBodyHtml)
                {
                    av.ContentType = new ContentType("text/html");
                }

                foreach (var resource in Resources)
                {
                    av.LinkedResources.Add(resource);
                }

                message.AlternateViews.Add(av);
            }

            var client = new SmtpClient(smtpServer)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = IsSecureConnection,
            };
            try
            {
                client.Send(message);
            }
            finally
            {
                message.Dispose();
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
    }
}
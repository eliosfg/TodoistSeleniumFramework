using EmailApplication.config;
using EmailApplication.Utils;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System.Net;
using System.Net.Mail;

namespace EmailApplication.Implementation
{
    internal class MailSender
    {
        private Config config;
        private FileManager fileManager;
        private SmtpSender sender;

        public MailSender()
        {
            config = new Config();
            fileManager = new FileManager(config.GetHtmlReportPath());
            sender = new SmtpSender(() => new SmtpClient(config.GetSmtpClient())
            {
                UseDefaultCredentials = false,
                Port = config.GetEmailPort(),
                Credentials = new NetworkCredential(config.GetEmailSender(), config.GetEmailPassword()),
                EnableSsl = true,
            });

            Email.DefaultSender = sender;
        }

        public async Task SendPlainTextEmail(string emailRecipient, string emailSubject, string emailBody)
        {
            var email = Email
                .From(config.GetEmailSender(), config.GetFrom())
                .To(emailRecipient)
                .Subject(emailSubject)
                .Body(emailBody);

            await email.SendAsync();
        }

        public async Task SendHtmlEmail(string emailRecipient, string emailSubject)
        {
            var email = Email
                .From(config.GetEmailSender(), config.GetFrom())
                .To(emailRecipient)
                .Subject(emailSubject)
                .UsingTemplateFromFile(fileManager.GetLastHtmlReportFile(),
                new
                {
                    Name = "Recipient Name",
                });

            await email.SendAsync();
        }
    }
}

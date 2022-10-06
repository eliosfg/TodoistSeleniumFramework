﻿using EmailApplication.config;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System.Net;
using System.Net.Mail;

namespace EmailApplication.Implementation
{
    internal class MailSender
    {
        private Config config;
        private SmtpSender sender;

        public MailSender()
        {
            config = new Config();
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
    }
}
//using EASendMail;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSenderEmail
{
    class SMTPSender : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public async Task<bool> SendMessage(string email, string html)
        {
            try
            {
                //danik22122005.realhost-free.net
                //SmtpServer server = new SmtpServer("danik22122005.realhost-free.net")
                //{
                //    Port = 25,
                //    ConnectType = SmtpConnectType.ConnectTryTLS,
                //    User = "support@jobjoin.tk",
                //    Password = "Qwerty-1"
                //};
                //SmtpMail message = new SmtpMail("TryIt")
                //{
                //    From = server.User,
                //    To = email,
                //    Subject = "Verification code with Win Viewer",
                //    //TextBody = html,
                //    Priority = MailPriority.High,
                //    HtmlBody = html
                //};
                //SmtpClient client = new SmtpClient();
                //client.SendMail(server, message);


                //SmtpServer server = new SmtpServer("smtp.gmail.com")
                //{
                //    Port = 587,
                //    ConnectType = SmtpConnectType.ConnectSSLAuto,
                //    User = "itstudentyre@gmail.com",
                //    Password = "Qw3eI98*63%"
                //};
                //SmtpMail message = new SmtpMail("TryIt")
                //{
                //    From = server.User,
                //    To = email,
                //    Subject = "Verification code with Win Viewer",
                //    //TextBody = html,
                //    Priority = MailPriority.High,
                //    HtmlBody = html
                //};
                //SmtpClient client = new SmtpClient();
                //client.SendMail(server, message);

                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("Администрация сайта", "support2@jobjoin.tk"));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = "hello";
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = html
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("danik22122005.realhost-free.net", 25, false);
                    await client.AuthenticateAsync("support@jobjoin.tk", "Qwerty-1");
                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}

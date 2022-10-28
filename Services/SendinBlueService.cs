using MailKit.Net.Smtp;
using MimeKit;

namespace DaviWebsite.Services
{
    public class SendinBlueService : IEmailService
    {

        public async Task SendEmailAsync(string fromName, string fromEmail, string subject, string msgTxt, string msgHtml)
        {
            var msg = new MimeMessage();
            var toEmail = Environment.GetEnvironmentVariable("BUSINESS_GMAIL");
            msg.From.Add(new MailboxAddress(fromName, fromEmail));
            msg.To.Add(MailboxAddress.Parse(toEmail));
            msg.Subject = subject;
            var builder = new BodyBuilder { TextBody = msgTxt, HtmlBody = msgHtml };
            msg.Body = builder.ToMessageBody();

            try
            {
                var smtpClient = new SmtpClient();
                smtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                var serverAddress = Environment.GetEnvironmentVariable("SERVER_ADDRESS");
                var serverPort = Int32.Parse(Environment.GetEnvironmentVariable("SERVER_PORT"));
                var serverPassword = Environment.GetEnvironmentVariable("SERVER_PASSWORD");
                await smtpClient.ConnectAsync(serverAddress, serverPort).ConfigureAwait(false);
                await smtpClient.AuthenticateAsync(toEmail, serverPassword).ConfigureAwait(false);
                await smtpClient.SendAsync(msg).ConfigureAwait(false);
                await smtpClient.DisconnectAsync(true).ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}

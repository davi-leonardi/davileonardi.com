namespace DaviWebsite.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string fromName, string fromEmail, string subject, string msgTxt, string msgHtml);
    }
}

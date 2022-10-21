using DaviWebsite.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;
using MimeKit.Text;
using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace DaviWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        [BindProperty]
        public EmailDTOModel EmailDTOModel { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            EmailDTOModel = new EmailDTOModel();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            try
            {
                ViewData["server-error"] = "False";
                var businessGmail = _configuration["businessGmail"];
                var apiKey = _configuration["SendGridApiKey"];
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("businessGmail", EmailDTOModel.Name);
                var subject = EmailDTOModel.Subject;
                var to = new EmailAddress("businessGmail", "Davi");
                var plainTextContent = EmailDTOModel.Body;
                var htmlContent = $"<strong>{EmailDTOModel.Email}</strong><br/><p>{EmailDTOModel.Body}</p>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = client.SendEmailAsync(msg);
            }
            catch
            {
                ViewData["server-error"] = "True";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
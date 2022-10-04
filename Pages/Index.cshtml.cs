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

namespace DaviWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public EmailDTOModel EmailDTOModel { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
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
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("dleonardimathey@gmail.com", EmailDTOModel.Name);
                var subject = EmailDTOModel.Subject;
                var to = new EmailAddress("dleonardimathey@gmail.com", "Davi");
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
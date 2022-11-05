using DaviWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DaviWebsite.Services;
using System.Text;

namespace DaviWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmailService _emailService;

        [BindProperty]
        public EmailDTOModel EmailDTOModel { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IEmailService emailService)
        {
            _logger = logger;
            EmailDTOModel = new EmailDTOModel();
            _emailService = emailService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            try
            {
                TempData["server-error"] = "False";

                var html = new StringBuilder();
                html.Append($"<p>{EmailDTOModel.Body}</p>");

                await _emailService.SendEmailAsync(EmailDTOModel.Name, EmailDTOModel.Email, EmailDTOModel.Subject, string.Empty, html.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["server-error"] = "True";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
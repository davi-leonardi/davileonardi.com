using DaviWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DaviWebsite.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        //OnPost() loads the form inputs in this prop (no need to specify the parameters)
        [BindProperty]
        public EmailModel EmailModel { get; set; } = new EmailModel();

        public void OnGet()
        {

        }

        //No args, auto loads EmailModel
        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
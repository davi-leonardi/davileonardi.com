using Microsoft.AspNetCore.Mvc;

namespace DaviWebsite.Models
{
    public class EmailModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty; 
    }
}

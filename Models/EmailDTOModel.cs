﻿using Microsoft.AspNetCore.Mvc;

namespace DaviWebsite.Models
{
    [BindProperties]
    public class EmailDTOModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Body { get; set; } = "";
    }
}

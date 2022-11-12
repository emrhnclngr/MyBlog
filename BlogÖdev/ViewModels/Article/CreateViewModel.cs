﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogÖdev.ViewModels.Article
{
    public class CreateViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        [Display(Name ="Article Picture")]
        public IFormFile ArticlePicture { get; set; }
    }
}

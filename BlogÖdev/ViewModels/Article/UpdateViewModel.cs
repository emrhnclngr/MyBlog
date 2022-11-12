using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogÖdev.ViewModels.Article
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ArticlePicture { get; set; }
        [NotMapped]
        public IFormFile NewImage { get; set; }
    }
}

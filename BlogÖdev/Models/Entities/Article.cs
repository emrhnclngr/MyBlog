using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogÖdev.Models.Entities
{
    [Table("Makaleler")]
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string ArticlePicture { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        [Required]
        public User Author { get; set; }
    }
}

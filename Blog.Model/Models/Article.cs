namespace Blog.Model.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        [Required]
        public int ArticleId { get; set; }
        [Required]
        public string ArticleTitle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
            
    }
}

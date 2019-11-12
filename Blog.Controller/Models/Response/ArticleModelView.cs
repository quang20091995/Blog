using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Controller.Models.Response
{
    public class ArticleModelView
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

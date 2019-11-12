using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Service.Models
{
    public class CreateArticleModelView
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleDescription { get; set; }
    }
}

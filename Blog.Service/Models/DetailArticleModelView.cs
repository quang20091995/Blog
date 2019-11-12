namespace Blog.Service.Models
{
    using System;
    public class DetailArticleModelView
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

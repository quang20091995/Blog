using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Controller.Models.Response
{
    public class DetailArticleResponse
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

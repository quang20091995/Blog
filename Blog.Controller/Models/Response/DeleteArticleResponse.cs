using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Controller.Models.Response
{
    public class DeleteArticleResponse
    {
        public int Deleted_Id { get; set; }
        public string Message { get; set; }
    }
}

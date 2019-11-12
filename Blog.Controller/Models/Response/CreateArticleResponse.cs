namespace Blog.Controller.Models.Response
{
    using Model.Models;
    public class CreateArticleResponse
    {
        public Article Created_Article { get; set; }
        public string Message { get; set; }
    }
}

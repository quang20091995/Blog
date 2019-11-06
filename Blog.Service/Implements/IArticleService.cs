namespace Blog.Service.Implements
{
    using Blog.Model.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<IEnumerable<Article>> CreateArticle(int ArticleId, string ArticleTitle, string ArticleDescription);
        Task<bool> EditArticle(int ArticleId, string ArticleTitle, string ArticleDescription);
        Task<bool> DeleteArticle(int ArticleId);
        Task<Article> GetDetail(int ArticleId);
    }
}

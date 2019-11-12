namespace Blog.Service.Implements
{
    using Model.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> CreateArticle(Article model);
        Task<bool> EditArticle(Article model);
        Task<bool> DeleteArticle(int ArticleId);
        Task<Article> GetDetail(int ArticleId);
    }
}

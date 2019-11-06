namespace Blog.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Blog.Model.Models;
    using Implements;
    public class ArticleService : IArticleService
    {
        public Task<IEnumerable<Article>> CreateArticle(int ArticleId, string ArticleTitle, string ArticleDescription)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteArticle(int ArticleId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditArticle(int ArticleId, string ArticleTitle, string ArticleDescription)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Article>> GetArticles()
        {
            throw new System.NotImplementedException();
        }

        public Task<Article> GetDetail(int ArticleId)
        {
            throw new System.NotImplementedException();
        }
    }
}

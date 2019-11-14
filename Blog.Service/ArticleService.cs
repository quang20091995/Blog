namespace Blog.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Implements;
    using Blog.Model.Models;
    using System;
    using Microsoft.EntityFrameworkCore;

    public class ArticleService : IArticleService
    {
        private readonly BlogDbContext db;
        public ArticleService(BlogDbContext db)
        {
            this.db = db;
        }

        public async Task<Article> CreateArticle(Article article)
        {
            await this.db.Articles.AddAsync(article);

            await this.db.SaveChangesAsync();
            

            return article;
        }

        public async Task<bool> DeleteArticle(int articleId)
        {
            var article = await this.db.Articles.FindAsync(articleId);

            if (article is null) {
                return false;
            }
            this.db.Articles.Remove(article);
            await this.db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditArticle(Article article)
        {
            var edit_article = this.db.Articles.Find(article.ArticleId);

            if(edit_article is null)
            {
                return false;
            }

            edit_article.ArticleTitle = article.ArticleTitle;
            edit_article.Description = article.Description;
            edit_article.CreatedOn = DateTime.Now;

            await this.db.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Article>> GetArticles()
            => await this.db.Articles.ToListAsync();
        

        public async Task<Article> GetDetail(int articleId)
            => await this.db.Articles.FindAsync(articleId);

    }
}

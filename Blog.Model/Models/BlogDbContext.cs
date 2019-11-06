namespace Blog.Model.Models
{
    using Microsoft.EntityFrameworkCore;
    public class BlogDbContext: DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Article> Articles { get; set; }
    }
}

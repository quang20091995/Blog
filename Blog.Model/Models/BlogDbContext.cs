namespace Blog.Model.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    public class BlogDbContext: IdentityDbContext<IdentityUser>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        // Creatin Roles for or application

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                    new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                    new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" },
                    new { Id = "3", Name = "Moderator", NormalizedName = "MODERATOR" }
                );
        }

        public DbSet<Article> Articles { get; set; }
    }
}

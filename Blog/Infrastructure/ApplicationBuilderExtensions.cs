namespace Blog.Infrastructure
{
    using Blog.Model.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMvcWithAreas(this IApplicationBuilder app)
           => app.UseMvc(routes =>
           {
               routes.MapRoute(
                   name: "default",
                   template: "{controller}/{action=Index}/{id?}");
           });

        public static IApplicationBuilder SeedDataAsync(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var dbContext = services.GetService<BlogDbContext>();

                dbContext.Database.MigrateAsync();
            }

            return app;
        }
    }
}

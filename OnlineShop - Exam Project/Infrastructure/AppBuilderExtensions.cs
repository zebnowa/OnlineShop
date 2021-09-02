namespace OnlineShop___Exam_Project.Infrastructure
{
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using OnlineShop___Exam_Project.Data;
    using OnlineShop___Exam_Project.Data.Model;

    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase
            (this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<OnlineShopDbContext>();

            data.Database.Migrate();

            SeedCategories(data);

            return app;
        }

        private static void SeedCategories(OnlineShopDbContext data)
        {
            if (data.Categorys.Any())
            {
                return ;
            }

            data.Categorys.AddRange(new[]
            {
                new Category{ Name = "Men"},
                new Category{ Name = "Women"},
                new Category{ Name = "Children"},
                new Category{ Name = "Babys"}
            });
            data.SaveChanges();
        }
    }
}

namespace OnlineShop___Exam_Project.Data
{
    using OnlineShop___Exam_Project.Data.Model;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class OnlineShopDbContext : IdentityDbContext
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
            : base(options)
        {
        }
        public DbSet<Shop> OnlineShops { get; init; }

        public DbSet<Category> Categorys { get; init; }

        public DbSet<Seller> Sellers { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Shop>()
                .HasOne(c => c.Category)
                .WithMany(s => s.OnlineShops)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Shop>()
                .HasOne(s => s.Seller)
                .WithMany(s => s.OnlineShops)
                .HasForeignKey(s => s.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            //връзка 1-1 П<=>Ю
            builder
                .Entity<Seller>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}

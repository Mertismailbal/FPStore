using FPStore.Core.Models;
using FPStore.Core.Models.Store;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FPStore.Repository.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<StoreProduct> StoreProduct { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Entity konfigürasyonlarınızı burada yapabilirsiniz
            // Örnek: builder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}

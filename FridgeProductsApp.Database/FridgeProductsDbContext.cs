using FridgeProductsApp.Domain.Configuration;
using FridgeProductsApp.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FridgeProductsApp.Database
{
    public class FridgeProductsDbContext : IdentityDbContext<User>
    {
        public FridgeProductsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FridgeConfiguration());
            modelBuilder.ApplyConfiguration(new FridgeProductConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<FridgeProduct> FridgeProducts { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

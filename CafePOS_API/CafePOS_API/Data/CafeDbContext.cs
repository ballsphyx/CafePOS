using CafePOS_API.Models.Entities;
using CafePOS_API.Models.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CafePOS_API.Data
{
    public class CafeDbContext(DbContextOptions<CafeDbContext> options) : IdentityDbContext<Employee>(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
                .HasData(
                new Category { Id = 1, CategoryName = "Drinks" },
                new Category { Id = 2, CategoryName = "Foods"}
                );
        }
    }
}

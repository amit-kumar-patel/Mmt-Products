using Microsoft.EntityFrameworkCore;
using MmtProducts.Domain;

namespace MmtProducts.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                     Id = 1,
                     Name = "Lamp",
                     Description = "It's a lamp",
                     Price = 100.00m,
                     Sku = 12345,
                     CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Hoe",
                    Description = "No, not that...",
                    Price = 100.00m,
                    Sku = 22345,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "TV",
                    Description = "You know what a TV is...",
                    Price = 200.00m,
                    Sku = 32345,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 4,
                    Name = "Dumbbells",
                    Description = "To make gains!",
                    Price = 425.00m,
                    Sku = 42345,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 5,
                    Name = "Barbie",
                    Description = "It's a doll",
                    Price = 100.00m,
                    Sku = 52345,
                    CategoryId = 5
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Home" },
                new Category { Id = 2, Name = "Garden" },
                new Category { Id = 3, Name = "Electronics" },
                new Category { Id = 4, Name = "Fitness" },
                new Category { Id = 5, Name = "Toys" }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using dotAshFashionNexus.Persistence.Models;
using System;

namespace dotAshFashionNexus.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, Name = "Product 1", SearchEngineFriendlyName = "product-1", CreatedDate = DateTime.UtcNow },
                new Product { ProductID = 2, Name = "Product 2", SearchEngineFriendlyName = "product-2", CreatedDate = DateTime.UtcNow },
                new Product { ProductID = 3, Name = "Product 3", SearchEngineFriendlyName = "product-3", CreatedDate = DateTime.UtcNow },
                new Product { ProductID = 4, Name = "Product 4", SearchEngineFriendlyName = "product-4", CreatedDate = DateTime.UtcNow },
                new Product { ProductID = 5, Name = "Product 5", SearchEngineFriendlyName = "product-5", CreatedDate = DateTime.UtcNow }
            );

            
            modelBuilder.Entity<Variant>().HasData(
                new Variant { VariantID = 1, ProductID = 1, Color = "Red", Size = "Small" },
                new Variant { VariantID = 2, ProductID = 1, Color = "Blue", Size = "Medium" },
                new Variant { VariantID = 3, ProductID = 2, Color = "Green", Size = "Large" },
                new Variant { VariantID = 4, ProductID = 3, Color = "Black", Size = "Small" },
                new Variant { VariantID = 5, ProductID = 4, Color = "White", Size = "Medium" }
            );

            
            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse { WarehouseID = 1, Name = "Warehouse 1" },
                new Warehouse { WarehouseID = 2, Name = "Warehouse 2" },
                new Warehouse { WarehouseID = 3, Name = "Warehouse 3" },
                new Warehouse { WarehouseID = 4, Name = "Warehouse 4" },
                new Warehouse { WarehouseID = 5, Name = "Warehouse 5" }
            );

            
            modelBuilder.Entity<Stock>().HasData(
                new Stock { StockID = 1, VariantID = 1, WarehouseID = 1, Quantity = 10 },
                new Stock { StockID = 2, VariantID = 2, WarehouseID = 2, Quantity = 20 },
                new Stock { StockID = 3, VariantID = 3, WarehouseID = 3, Quantity = 30 },
                new Stock { StockID = 4, VariantID = 4, WarehouseID = 4, Quantity = 40 },
                new Stock { StockID = 5, VariantID = 5, WarehouseID = 5, Quantity = 50 }
            );
        }
    }
}

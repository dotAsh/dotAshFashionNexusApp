//Developed by Md. Ashik
using dotAshFashionNexus.Persistence.Data;
using dotAshFashionNexus.Persistence.Models;
using dotAshFashionNexus.Persistence.Models.DTO;
using dotAshFashionNexus.Persistence.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Linq.Expressions;

namespace dotAshFashionNexus.Persistence.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private  IMemoryCache _memoryCache;
        public ProductRepository(ApplicationDbContext db, IMemoryCache memoryCache) : base(db, memoryCache) 
        {
            _db = db;
            _memoryCache = memoryCache;
        }
       

 
        public async Task<Product> UpdateAsync(Product entity)
        {
           
            _db.Products.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<IQueryable<ProductStockDTO>> GetAllProductsAsync(ProductFilterCriteria filterCriteria){



            var joinedQuery = from product in _db.Products
                              join variant in _db.Variants on product.ProductID equals variant.ProductID
                              join stock in _db.Stocks on variant.VariantID equals stock.VariantID
                              join warehouse in _db.Warehouses on stock.WarehouseID equals warehouse.WarehouseID
                              select new ProductStockDTO
                              {
                                  ProductID = product.ProductID,
                                  Name = product.Name,
                                  SearchEngineFriendlyName = product.SearchEngineFriendlyName,
                                  CreatedDate = product.CreatedDate,
                                  VariantID = variant.VariantID,
                                  Color = variant.Color,
                                  Size = variant.Size,
                                  Stocks = variant.Stocks.Select(s => new StockDTO
                                  {
                                      StockID = s.StockID,
                                      Quantity = s.Quantity,
                                      Warehouse = new WarehouseDTO
                                      {
                                          WarehouseID = s.Warehouse.WarehouseID,
                                          Name = s.Warehouse.Name
                                      }
                                  }).AsQueryable()
                              };
           
            return joinedQuery;
        }

    }
}

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
        public async Task<IEnumerable<Object>> GetAllProductsAsync(ProductFilterCriteria filterCriteria){
           
            var query = from product in _db.Products
                        from variant in product.Variants
                        from stock in variant.Stocks
                        where (string.IsNullOrEmpty(filterCriteria.ProductName) || product.Name.Contains(filterCriteria.ProductName)) &&
                              (filterCriteria.InStock ? stock.Quantity > 0 : stock.Quantity == 0) &&

                              (string.IsNullOrEmpty(filterCriteria.VariantColor) || variant.Color == filterCriteria.VariantColor) &&
                              (string.IsNullOrEmpty(filterCriteria.VariantSize) || variant.Size == filterCriteria.VariantSize) &&
                              (string.IsNullOrEmpty(filterCriteria.WarehouseName) || stock.Warehouse.Name == filterCriteria.WarehouseName)
                        orderby product.CreatedDate
                        select new
                        {
                            ProductID = product.ProductID,
                            Name = product.Name,
                            SearchEngineFriendlyName = product.SearchEngineFriendlyName,
                            CreatedOn = product.CreatedDate,
                            VariantID = variant.VariantID,
                            Color = variant.Color,
                            Size = variant.Size,
                            Stocks = from stock in variant.Stocks
                                     select new
                                     {
                                         StockID = stock.StockID,
                                         Quantity = stock.Quantity,
                                         Warehouse = new
                                         {
                                             WarehouseID = stock.Warehouse.WarehouseID,
                                             Name = stock.Warehouse.Name
                                         }
                                     }
                        };

            

            var paginatedQuery = query.Skip((filterCriteria.PageNumber - 1) * filterCriteria.PageSize)
                                      .Take(filterCriteria.PageSize);


            return await paginatedQuery.ToListAsync();
        }

    }
}

using dotAshFashionNexus.Persistence.Models;
using dotAshFashionNexus.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotAshFashionNexus.Service.IServices
{
    public interface IProductService
    {
        public Task<IEnumerable<Object>> GetAllProductsAsync(ProductFilterCriteria filterCriteria);
        Task<Product> GetProductByNameAsync(string SearchEngineFriendlyName);
        public Task<Stock> UpdateStockAsync(int stockID, int variantId, int warehouseId, int quantity);
        
    }

}

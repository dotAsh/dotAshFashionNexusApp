using dotAshFashionNexus.Persistence.Models;
using dotAshFashionNexus.Persistence.Models.DTO;
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
        public Task<IEnumerable<ProductStockDTO>> GetAllProductsAsync(ProductFilterCriteriaDTO filterCriteria);
        Task<ProductDTO> GetProductByNameAsync(string SearchEngineFriendlyName);
        public Task UpdateStockAsync(int stockID, int variantId, int warehouseId, int quantity);
        
    }

}

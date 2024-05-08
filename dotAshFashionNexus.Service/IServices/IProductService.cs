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
        Task<List<ProductDTO>> GetAllProductsAsync(string filterBy = null, string sortBy = null, int pageSize = 10, int pageNumber = 1);
        Task<ProductDTO> GetProductByIdAsync(int id);

        
    }

}

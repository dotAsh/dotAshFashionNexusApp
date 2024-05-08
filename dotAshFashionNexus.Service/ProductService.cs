//Developed by Md. Ashik
using dotAshFashionNexus.Persistence.Models;
using dotAshFashionNexus.Service.DTO;
using dotAshFashionNexus.Persistence.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dotAshFashionNexus.Service.Mappers;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using dotAshFashionNexus.Service.IServices;
//Developed by Md. Ashik
namespace dotAshFashionNexus.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync(string filterBy = null, string sortBy = null, int pageSize = 10, int pageNumber = 1)
        {
            List<Product> productList;
            if (filterBy != null)
            {
                productList = await _productRepository.GetAllAsync(filter: u => u.Name.Contains(filterBy), pageSize: pageSize, pageNumber: pageNumber);
            }
            else
            {
                productList = await _productRepository.GetAllAsync(pageSize: pageSize, pageNumber: pageNumber);
            }

            if (!string.IsNullOrEmpty(sortBy) && productList != null)
            {
                var property = typeof(Product).GetProperty(sortBy);
                if (property != null)
                {

                    productList = productList.OrderBy(x => property.GetValue(x)).ToList();
                }
            }
            return productList.MapToDTOList();
        }

      

      

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {

            try
            {
                var product = await _productRepository.GetAsync(x => x.ProductID == id, false);
                if (product == null)
                {
                    return null;
                }

                return product.MapToDto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       


    }

}

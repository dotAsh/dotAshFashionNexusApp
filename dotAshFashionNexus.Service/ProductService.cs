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
using AutoMapper;
using dotAshFashionNexus.Persistence.Models.DTO;
//Developed by Md. Ashik
namespace dotAshFashionNexus.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IStockRepository stockRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<Object>> GetAllProductsAsync(ProductFilterCriteriaDTO filterCriteriaDTO)
        {


            IEnumerable<Object> productList;
            
            productList = await _productRepository.GetAllProductsAsync(_mapper.Map<ProductFilterCriteria>(filterCriteriaDTO));

            return productList;
        }


        public async Task UpdateStockAsync(int stockID, int variantId, int warehouseId, int quantity)
        {
            try
            {
                var stock = await _stockRepository.GetAsync(x => x.StockID == stockID && x.VariantID == variantId && x.WarehouseID == warehouseId ,false);
               
                if (stock != null && stock.Quantity >= quantity)
                {
                    stock.Quantity -= quantity;
                     await _stockRepository.UpdateAsync(stockID, variantId, warehouseId, quantity);
                }
                

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        public async Task<ProductDTO> GetProductByNameAsync(string SearchEngineFriendlyName)
        {

            try
            {
                var product = await _productRepository.GetAsync(x => x.SearchEngineFriendlyName == SearchEngineFriendlyName, false);
                if (product == null)
                {
                    return null;
                }
                return _mapper.Map<ProductDTO>(product);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }

}

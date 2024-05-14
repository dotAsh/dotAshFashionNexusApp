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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
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

        public async Task<IEnumerable<ProductStockDTO>> GetAllProductsAsync(ProductFilterCriteriaDTO filterCriteria)
        {


            
            
            IQueryable<ProductStockDTO> joinedQuery = await _productRepository.GetAllProductsAsync(_mapper.Map<ProductFilterCriteria>(filterCriteria));
            var list = joinedQuery
                 .Where(jr =>
                     (string.IsNullOrEmpty(filterCriteria.ProductName) || jr.Name.Contains(filterCriteria.ProductName)) &&
                     (filterCriteria.InStock ? jr.Stocks.Any(s => s.Quantity > 0) : jr.Stocks.All(s => s.Quantity == 0)) &&
                     (string.IsNullOrEmpty(filterCriteria.VariantColor) || jr.Color == filterCriteria.VariantColor) &&
                     (string.IsNullOrEmpty(filterCriteria.VariantSize) || jr.Size == filterCriteria.VariantSize) &&
                     (string.IsNullOrEmpty(filterCriteria.WarehouseName) || jr.Stocks.Any(s => s.Warehouse.Name == filterCriteria.WarehouseName)))
                 .OrderBy(jr => jr.CreatedDate)
                 .ThenByDescending(jr => jr.Stocks.Sum(s => s.Quantity))
                 .Skip((filterCriteria.PageNumber - 1) * filterCriteria.PageSize)
                 .Take(filterCriteria.PageSize).ToList();




            list = list.GroupBy(jr => new { jr.ProductID, jr.VariantID })
           .Select(g => g.First())
           .ToList();


            return list;
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

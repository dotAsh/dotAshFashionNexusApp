using dotAshFashionNexus.Persistence.Models;
using dotAshFashionNexus.Service.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotAshFashionNexus.Persistence.Models.DTO;

namespace dotAshFashionNexus.Service.Mappers
{
    public static class Mapper
    {
       
        public static ProductDTO MapToDto(this Product product)
        {
            if (product == null)
            {
                return null;

            }
                

            return new ProductDTO
            {
                ProductID = product.ProductID,
                Name = product.Name,
                SearchEngineFriendlyName = product.SearchEngineFriendlyName,
                
            };
        }

        

        public static List<ProductDTO> MapToDTOList(this IEnumerable<Product> Products)
        {
            var productDTOList = new List<ProductDTO>();
            foreach (var product in Products)
            {
                productDTOList.Add(product.MapToDto());
            }
            return productDTOList;
        }

      
    }
}

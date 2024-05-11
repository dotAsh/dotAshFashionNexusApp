using AutoMapper;
using dotAshFashionNexus.Persistence.Models;
using dotAshFashionNexus.Persistence.Models.DTO;
using dotAshFashionNexus.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotAshFashionNexus.Service
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            

            CreateMap<ProductFilterCriteriaDTO, ProductFilterCriteria>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
            


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotAshFashionNexus.Persistence.Models.DTO
{
    public class ProductFilterCriteria
    {
        public bool InStock { get; set; }
        public string VariantColor { get; set; }
        public string VariantSize { get; set; }
        public string WarehouseName { get; set; }
        public string ProductName { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
    
}

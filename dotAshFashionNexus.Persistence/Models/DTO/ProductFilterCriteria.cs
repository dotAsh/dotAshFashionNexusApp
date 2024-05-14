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
    public class ProductStockDTO
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string SearchEngineFriendlyName { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int VariantID { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public IEnumerable<StockDTO> Stocks { get; set; } // A list of stocks associated with the variant

        // Constructor to initialize the list of stocks
        public ProductStockDTO()
        {
            Stocks = new List<StockDTO>();
        }
    }

    public class StockDTO
    {
        public int StockID { get; set; }
        public int Quantity { get; set; }
        public WarehouseDTO Warehouse { get; set; } // Warehouse information associated with the stock
    }

    public class WarehouseDTO
    {
        public int WarehouseID { get; set; }
        public string Name { get; set; }
    }



}

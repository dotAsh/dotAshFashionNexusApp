using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotAshFashionNexus.Service.DTO
{


    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string SearchEngineFriendlyName { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public List<VariantDTO> Variants { get; set; }
    }
    public class VariantDTO
    {
        public int VariantID { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public List<StockDTO> Stocks { get; set; }
    }

    public class StockDTO
    {
        public int StockID { get; set; }
        public int Quantity { get; set; }
        public WarehouseDTO Warehouse { get; set; }
    }

    public class WarehouseDTO
    {
        public int WarehouseID { get; set; }
        public string Name { get; set; }
    }

}

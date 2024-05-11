using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotAshFashionNexus.Persistence.Models
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
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("SearchEngineFriendlyName")]
        public  string SearchEngineFriendlyName { get; set; }

        [Required]
        [Column("CreatedOn")]
        public DateTimeOffset CreatedDate { get; set; }

        public ICollection<Variant> Variants { get; set; }
    }
}

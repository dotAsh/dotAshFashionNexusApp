using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotAshFashionNexus.Persistence.Models
{
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StockID { get; set; }

        [Required]
        public int VariantID { get; set; }

        [ForeignKey("VariantID")]
        public Variant Variant { get; set; }

        [Required]
        public int WarehouseID { get; set; }

        [ForeignKey("WarehouseID")]
        public Warehouse Warehouse { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotAshFashionNexus.Persistence.Models
{
   
    public class Variant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VariantID { get; set; }
        public int ProductID { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

       
        public Product Product { get; set; }

        
        public ICollection<Stock> Stocks { get; set; }
    }
}

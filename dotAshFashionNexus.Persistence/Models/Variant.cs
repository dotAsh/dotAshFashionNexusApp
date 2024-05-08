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

        [Required]
        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [Required]
        [MaxLength(50)]
        public string Color { get; set; }

        [Required]
        [MaxLength(50)]
        public string Size { get; set; }
    }
}

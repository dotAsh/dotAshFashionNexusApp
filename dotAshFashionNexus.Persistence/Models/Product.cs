using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotAshFashionNexus.Persistence.Models
{
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
    }
}

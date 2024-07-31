using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9_ProgettoSettimanale.Models
{
    public class Products
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Range(0, 100)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required, StringLength(128)]
        public required string Photo { get; set; }

        [Range(0, 60)]
        public int DeliveryTimeInMinutes { get; set; }

        public List<Ingredients> Ingredients { get; set; } = [];

        public List<OrderedProduct> OrderedProduct { get; set; } = [];

    }
}

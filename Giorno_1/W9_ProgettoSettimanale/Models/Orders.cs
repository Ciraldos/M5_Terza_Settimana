using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9_ProgettoSettimanale.Models
{
    public class Orders
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime PlacedAt { get; set; }

        public required Users User { get; set; }

        public bool IsConfirmed { get; set; }

        public bool Done { get; set; }

        [Column(TypeName = "decimal(18, 2)")]

        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(80)]
        public required string Address { get; set; }

        [StringLength(255)]
        public string? Notes { get; set; }

        public List<OrderedProduct> OrderedProducts { get; set; } = [];

    }
}

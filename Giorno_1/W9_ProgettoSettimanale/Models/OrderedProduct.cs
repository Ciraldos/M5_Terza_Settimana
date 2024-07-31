using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9_ProgettoSettimanale.Models
{
    public class OrderedProduct
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required Products Product { get; set; }

        public required Orders Order { get; set; }

        public int Quantity { get; set; }
    }
}
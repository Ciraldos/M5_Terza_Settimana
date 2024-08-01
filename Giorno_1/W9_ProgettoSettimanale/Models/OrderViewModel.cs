using System.ComponentModel.DataAnnotations;

namespace W9_ProgettoSettimanale.Models
{
    public class OrderViewModel
    {
        // Lista degli articoli ordinati
        public List<OrderedProductDetail> OrderedProducts { get; set; } = [];

        // Costo totale dell'ordine
        public decimal TotalAmount { get; set; }

        // Indirizzo di spedizione
        [Required(ErrorMessage = "L'indirizzo di spedizione è obbligatorio.")]
        [StringLength(80, ErrorMessage = "L'indirizzo non può superare i 80 caratteri.")]
        public string ShippingAddress { get; set; }

        // Note aggiuntive
        [StringLength(255, ErrorMessage = "Le note non possono superare i 255 caratteri.")]
        public string? Notes { get; set; }

        // Classe per rappresentare i dettagli degli articoli ordinati
        public class OrderedProductDetail
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal ProductPrice { get; set; }
            public int Quantity { get; set; }
        }

    }
}

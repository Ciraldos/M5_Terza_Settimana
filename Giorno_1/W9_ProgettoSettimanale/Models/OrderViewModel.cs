namespace W9_ProgettoSettimanale.Models
{
    public class OrderViewModel
    {
        public required Orders Order { get; set; }
        public List<Products> Products { get; set; } = [];
        public List<int> SelectedProductIds { get; set; } = [];
    }
}

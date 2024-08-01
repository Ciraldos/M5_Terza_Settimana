namespace W9_ProgettoSettimanale.Models
{
    public class ProductsViewModel
    {
        public Products Products { get; set; }
        public List<Ingredients> Ingredients { get; set; }

        public List<int> SelectedIngredients { get; set; }
    }
}

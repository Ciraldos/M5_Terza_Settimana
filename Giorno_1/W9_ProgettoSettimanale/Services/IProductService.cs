using W9_ProgettoSettimanale.Models;

namespace W9_ProgettoSettimanale.Services
{
    public interface IProductService
    {
        public Task<Products> CreateProductAsync(ProductsViewModel p);
        public Task<List<Products>> GetProductsAsync();


    }
}

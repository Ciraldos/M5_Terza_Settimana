using Microsoft.EntityFrameworkCore;
using W9_ProgettoSettimanale.Context;
using W9_ProgettoSettimanale.Models;

namespace W9_ProgettoSettimanale.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _ctx;
        public ProductService(DataContext dataContext)
        {
            _ctx = dataContext;
        }
        public async Task<Products> CreateProductAsync(ProductsViewModel p)
        {
            var pr = new Products
            {
                Name = p.Products.Name,
                Price = p.Products.Price,
                Photo = p.Products.Photo,
                DeliveryTimeInMinutes = p.Products.DeliveryTimeInMinutes,
                Ingredients = await _ctx.Ingredients.Where(i => p.SelectedIngredients.Contains(i.Id)).ToListAsync()
            };
            await _ctx.Products.AddAsync(pr);
            await _ctx.SaveChangesAsync();
            return pr;
        }

        public async Task<List<Products>> GetProductsAsync()
        {
            return await _ctx.Products.Include(p => p.Ingredients).ToListAsync();
        }

    }
}

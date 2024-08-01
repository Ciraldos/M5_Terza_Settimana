using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W9_ProgettoSettimanale.Context;
using W9_ProgettoSettimanale.Models;
using W9_ProgettoSettimanale.Services;

namespace W9_ProgettoSettimanale.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly DataContext _ctx;
        private readonly IProductService _productService;

        public ProductsController(DataContext dbContext, IProductService productService)
        {
            _ctx = dbContext;
            _productService = productService;
        }

        public IActionResult CreateProdotto()
        {
            ViewBag.AllIngredients = _ctx.Ingredients.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProdotto(ProductsViewModel p)
        {
            await _productService.CreateProductAsync(p);
            return RedirectToAction("GetProdotti");

        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> GetProdotti()
        {
            var p = await _productService.GetProductsAsync();
            return View(p);
        }

        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var product = await _ctx.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            var order = await GetOrCreateCurrentOrderAsync();

            var orderedProduct = new OrderedProduct
            {
                Order = order,
                Product = product,
                Quantity = quantity
            };

            order.OrderedProducts.Add(orderedProduct);
            _ctx.Update(order);
            await _ctx.SaveChangesAsync();

            return RedirectToAction(nameof(GetProdotti));
        }


    }
}

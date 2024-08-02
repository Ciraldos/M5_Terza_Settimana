using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProdotto(ProductsViewModel p)
        {
            await _productService.CreateProductAsync(p);
            return RedirectToAction("GetProdotti");

        }

        public async Task<IActionResult> GetProdotti()
        {
            var p = await _productService.GetProductsAsync();
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var userName = User.Identity.Name;
            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.Name == userName);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var order = await _ctx.Orders
                .Include(o => o.OrderedProducts)
                .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync(o => o.User.Id == user.Id && !o.IsConfirmed);

            if (order == null)
            {
                order = new Orders
                {
                    User = user,
                    PlacedAt = DateTime.Now,
                    Done = false,
                    Address = "Indirizzo di default",
                    IsConfirmed = false,
                };

                _ctx.Orders.Add(order);
            }

            var product = await _ctx.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            // Trova il prodotto ordinato esistente, se c'è
            var existingOrderedProduct = order.OrderedProducts
                .FirstOrDefault(op => op.Product.Id == productId);

            if (existingOrderedProduct != null)
            {
                // Se il prodotto esiste nel carrello aggiorna la quantità
                existingOrderedProduct.Quantity += quantity;
            }
            else
            {
                // Altrimenti aggiungi un nuovo prodotto ordinato
                var orderedProduct = new OrderedProduct
                {
                    Order = order,
                    Product = product,
                    Quantity = quantity
                };

                order.OrderedProducts.Add(orderedProduct);
            }
            await _ctx.SaveChangesAsync();
            return RedirectToAction("GetProdotti");
        }

    }
}

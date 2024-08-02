using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using W9_ProgettoSettimanale.Context;
using W9_ProgettoSettimanale.Models;
using W9_ProgettoSettimanale.Services;

namespace W9_ProgettoSettimanale.Controllers
{
    public class OrderController : Controller
    {
        private readonly DataContext _ctx;
        private readonly IOrderService _orderService;

        public OrderController(DataContext dataContext, IOrderService orderService)
        {
            _ctx = dataContext;
            _orderService = orderService;

        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Orders()
        {
            var ordini = await _ctx.Orders.Include(o => o.User).ToListAsync();
            return View(ordini);
        }

        public async Task<IActionResult> Order()
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
                return RedirectToAction("NoOrder");

            }

            var viewModel = new OrderViewModel
            {
                TotalAmount = order.OrderedProducts.Sum(op => op.Product.Price * op.Quantity),
                ShippingAddress = order.Address,
                Notes = order.Notes,
                OrderedProducts = order.OrderedProducts.Select(op => new OrderViewModel.OrderedProductDetail
                {
                    ProductId = op.Product.Id,
                    ProductName = op.Product.Name,
                    ProductPrice = op.Product.Price,
                    Quantity = op.Quantity
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetNumbersProductFromOrders()
        {
            var userName = User.Identity.Name;
            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.Name == userName);

            var totalProducts = await _ctx.Orders
                                  .Where(o => o.User.Id == user.Id && !o.IsConfirmed)
                                  .SelectMany(o => o.OrderedProducts).SumAsync(o => o.Quantity);
            return Ok(totalProducts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CompleteOrder(OrderViewModel model)
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
                return RedirectToAction("NoOrder");
            }
            var totalamount = order.OrderedProducts.Sum(op => op.Product.Price * op.Quantity);
            order.Address = model.ShippingAddress;
            order.Notes = model.Notes;
            order.PlacedAt = DateTime.Now;
            order.TotalAmount = totalamount;
            order.IsConfirmed = true;



            await _ctx.SaveChangesAsync();

            return RedirectToAction("CompletedOrder");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrdine(int id)
        {
            var order = await _ctx.Orders.FindAsync(id);
            _ctx.Orders.Remove(order);
            await _ctx.SaveChangesAsync();
            return RedirectToAction("Orders");
        }


        public async Task<IActionResult> IsDone()
        {
            var ordini = await _ctx.Orders.Where(o => o.Done == false).ToListAsync();
            return View(ordini);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> IsDone(int id)
        {
            var order = await _ctx.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            order.Done = true;
            await _ctx.SaveChangesAsync();
            return RedirectToAction("IsDone");
        }

        [HttpGet]
        public async Task<IActionResult> Count()
        {
            var c = await _ctx.Orders.CountAsync(o => o.Done == true);
            return Ok(c);
        }

        [HttpGet]
        public async Task<IActionResult> AmountFromDay(DateTime date)
        {
            var total = await _ctx.Orders
                                  .Where(o => o.Done == true && o.PlacedAt.Date == date.Date)
                                  .SumAsync(o => o.TotalAmount);
            return Ok(total);
        }
        public IActionResult CompletedOrder()
        {
            return View();
        }


        public IActionResult NoOrder()
        {
            return View();
        }
    }
}

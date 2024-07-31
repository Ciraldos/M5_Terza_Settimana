using Microsoft.AspNetCore.Mvc;
using W9_ProgettoSettimanale.Context;
using W9_ProgettoSettimanale.Models;

namespace W9_ProgettoSettimanale.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataContext _ctx;

        public AdminController(DataContext dbContext)
        {
            _ctx = dbContext;
        }

        public IActionResult CreateProdotto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProdotto(Products p, int ingredientId)
        {
            // Fetch the ingredient from the database using the provided ID
            var ingredient = _ctx.Ingredients.FirstOrDefault(i => i.Id == ingredientId);

            // Check if the ingredient exists
            if (ingredient == null)
            {
                return NotFound(); // or handle the error as appropriate
            }

            // Initialize the Ingredients collection if it is null
            if (p.Ingredients == null)
            {
                p.Ingredients = new List<Ingredients>();
            }

            // Add the ingredient to the product's Ingredients list
            p.Ingredients.Add(ingredient);

            // Add the product to the database context
            _ctx.Products.Add(p);

            // Save changes to the database
            _ctx.SaveChanges();

            // Redirect to the Home/Index action
            return RedirectToAction("GetProdotti");
        }

        public IActionResult GetProdotti()
        {
            return View(_ctx.Products);
        }

    }
}

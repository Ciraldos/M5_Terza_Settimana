using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W9.D1.EntityFramework.DataModel;
using W9.D1.EntityFramework.Models;

namespace W9.D1.EntityFramework.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogDbContext _dbContext;

        public HomeController(BlogDbContext dataContext, ILogger<HomeController> logger) {
            _logger = logger;
            _dbContext = dataContext;
        }

        public IActionResult Index() {
            return View(_dbContext.Authors); //.Where(a => a.FirstName.ToLower().StartsWith("p")));
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author) {
            if (ModelState.IsValid) {
                _dbContext.Authors.Add(author);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        public IActionResult Edit(int id) {
            var author = _dbContext.Authors.Single(a => a.Id == id);
            return View(author);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author) {
            if (ModelState.IsValid) {
                var a = _dbContext.Authors.Single(a => a.Id == author.Id);
                a.LastName = author.LastName;
                a.FirstName = author.FirstName;
                a.Email = author.Email;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }
        public IActionResult Delete(int id) {
            var author = _dbContext.Authors.Single(a => a.Id == id);
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Author author) {
            var a = _dbContext.Authors.Single(a => a.Id == author.Id);
            _dbContext.Authors.Remove(a);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

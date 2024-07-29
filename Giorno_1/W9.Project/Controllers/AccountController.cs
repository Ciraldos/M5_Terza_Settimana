using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using W9.Project.DataLayer.AppContext;
using W9.Project.Models;

namespace W9.Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly W9PizzeriaContext _ctx;

        public AccountController(W9PizzeriaContext ctx) {
            _ctx = ctx;
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model) {
            if (ModelState.IsValid) {
                var user = _ctx.Users
                    .Include(u => u.UsersRoles)
                    .ThenInclude(ur => ur.Role)
                    .SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user == null)
                    TempData["User"] = "Anonimo";
                else {
                    TempData["User"] = user.Email;
                    var roles = user.UsersRoles.Select(ur => ur.Role.Name).ToArray();
                    TempData["Roles"] = roles;
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}

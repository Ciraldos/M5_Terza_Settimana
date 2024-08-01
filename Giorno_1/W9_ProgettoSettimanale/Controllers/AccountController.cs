using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using W9_ProgettoSettimanale.Models;
using W9_ProgettoSettimanale.Services;

namespace W9_ProgettoSettimanale.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Users u)
        {
            await _authService.Register(u);
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Users u)
        {
            var user = await _authService.Login(u);
            if (user == null)
            {
                return RedirectToAction("Register");
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name)
                };

            user.Roles.ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r.Name)));


            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return RedirectToAction("GetProdotti", "Admin");
        }



        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}

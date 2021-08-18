using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PreSemesterProject.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using PreSemesterProject.Models.ViewModels;
using PreSemesterProject.Services.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using PreSemesterProject.Repository;
using Microsoft.AspNetCore.Authentication;

namespace PreSemesterProject.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService;

        public HomeController(ILogger<HomeController> logger, IAuthService authService, FakeRepository repository)
        {
            _logger = logger;
            _authService = authService;
        }

        [Authorize("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SessionKeyAdmin")))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            User user = _authService.ValidateLogin(login);
            if (user is null)
            {
                return View();
            }

            ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                foreach(string role in user.Roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            HttpContext.Session.SetString("SessionKey", login.Username);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

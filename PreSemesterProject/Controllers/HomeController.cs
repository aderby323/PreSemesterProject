using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PreSemesterProject.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using PreSemesterProject.Models.ViewModels;
using PreSemesterProject.Services.Interfaces;

namespace PreSemesterProject.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService;

        public HomeController(ILogger<HomeController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionKeyAdmin")))
            {
                return RedirectToAction("Login");
            }

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
            if (_authService.ValidateLogin(login))
            {
                HttpContext.Session.SetString("SessionKeyAdmin", login.Username);
                return RedirectToAction("Index");
            }

            return NotFound();
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

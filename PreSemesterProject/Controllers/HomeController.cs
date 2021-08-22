using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreSemesterProject.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using PreSemesterProject.Models.ViewModels;
using PreSemesterProject.Services.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using PreSemesterProject.Repository;
using Microsoft.AspNetCore.Authentication;
using PreSemesterProject.Models.DBModels;
using System.Linq;

namespace PreSemesterProject.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IAuthService _authService;
        private readonly VolunteerManagementSystemContext _context;

        public HomeController(IAuthService authService, VolunteerManagementSystemContext context)
        {
            _authService = authService;
            _context = context;
        }

        [Authorize("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            ViewData["ErrorMessage"] = null;
            User user = _authService.ValidateLogin(login);
            if (user is null)
            {
                ViewData["ErrorMessage"] = "Username or password is incorrect.";
                return View();
            }

            string role = _context.UserRoles.Where(x => x.Username.Equals(user.Username)).FirstOrDefault().Role;

            ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                identity.AddClaim(new Claim(ClaimTypes.Role, role));

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Logout() 
        {
            if (!User.Identity.IsAuthenticated) { return BadRequest("Not logged in to the system."); }

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
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

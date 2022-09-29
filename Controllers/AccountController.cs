using CompanyMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CompanyMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(ILogger<AccountController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                return View(user);
            }
            return View("Index", "Home");
        }
    }
}
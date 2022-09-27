using CompanyMvc.Models;
using CompanyMvc.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CompanyMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManager;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel registration)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    Email = registration.Email,
                    UserName = registration.FirstName,
                    PhoneNumber = registration.PhoneNumber,
                    NationalId = registration.NationalId,
                    FirstName = registration.FirstName,
                    LastName = registration.LastName
                };
                var result = await _userManager.CreateAsync(user, registration.Password);
                if (result.Succeeded)
                {
                    await _signManager.SignInAsync(user, false);
                    return RedirectToAction(nameof(Index), "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                var result = await _signManager.PasswordSignInAsync(user.UserName, loginViewModel.Password, loginViewModel.Remember, false);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index), "Home");
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "home");
        }

    }
}
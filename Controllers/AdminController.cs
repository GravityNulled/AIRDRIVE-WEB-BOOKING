using CompanyMvc.Data;
using CompanyMvc.Models;
using CompanyMvc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyMvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dBcontext;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext dBcontext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dBcontext = dBcontext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRole)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole()
                {
                    Name = createRole.RoleName
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ListRoutes()
        {
            var routes = await _dBcontext.BusRoutes.ToListAsync();
            return View(routes);
        }

        [HttpGet]
        public IActionResult Route()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Route(BusRoute busRoute)
        {
            if (ModelState.IsValid)
            {
                _dBcontext.BusRoutes.Add(busRoute);
                await _dBcontext.SaveChangesAsync();
                return RedirectToAction(nameof(ListRoutes));
            }
            return View();
        }

    }
}
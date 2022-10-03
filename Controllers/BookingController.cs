using CompanyMvc.Data;
using CompanyMvc.Helpers;
using CompanyMvc.Models;
using CompanyMvc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CompanyMvc.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        public BookingController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Ticket()
        {
            var Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "Cart");
            ViewBag.Cart = Cart;
            foreach (var item in Cart)
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                    var book = new Booking()
                    {
                        Price = item.BusModel.Price,
                        Name = user.FirstName + " " + user.LastName,
                        Phone = user.PhoneNumber,
                        Destination = item.BusModel.Destination,
                        Source = item.BusModel.Source,
                        BusId = item.BusModel.BusId,
                        DeputureTime = item.BusModel.DepartureTime
                    };
                    return View(book);
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
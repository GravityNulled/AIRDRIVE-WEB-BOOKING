using CompanyMvc.Helpers;
using CompanyMvc.Models;
using CompanyMvc.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CompanyMvc.Controllers
{
    public class BookingController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public BookingController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Home()
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
                        ApplicationUserId = user.Id,
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
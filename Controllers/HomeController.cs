using Microsoft.AspNetCore.Mvc;
using CompanyMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using CompanyMvc.Data;
using CompanyMvc.Models;
using Microsoft.EntityFrameworkCore;
using CompanyMvc.Helpers;

namespace CompanyMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dbContext;
    private static List<BusModel> FoundbusesList = new List<BusModel>();
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var routes = _dbContext.BusRoutes.ToList();
        var model = new RoutesViewModel();
        model.SelectListSource = new List<SelectListItem>();
        model.SelectListDestination = new List<SelectListItem>();
        foreach (var route in routes)
        {
            model.SelectListSource.Add(new SelectListItem { Text = route.Source, Value = route.RouteTag });
            model.SelectListDestination.Add(new SelectListItem { Text = route.Source, Value = route.RouteTag });
        }
        return View(model);
    }

    [HttpPost]
    public async Task<ActionResult> Index(RoutesViewModel routesViewModel)
    {
        var route = routesViewModel.SelectedRouteTag;
        DateTime travelDate = routesViewModel.TravelDate;
        var routeBuses = _dbContext.BusRoutes.Where(t => t.RouteTag == route).ToList();
        if (routeBuses == null) return RedirectToAction(nameof(Index));
        foreach (var routeBus in routeBuses)
        {
            var busFound = await _dbContext.Buses.Where(id => id.BusId == Convert.ToInt32(routeBus.BusId)).ToListAsync();
            if (busFound == null) return RedirectToAction(nameof(Index));
            var currentBus = busFound.Join(routeBuses, b => b.BusId, r => r.BusId, (b, r) => new BusModel
            {
                BusId = b.BusId,
                BusNo = b.BusNo,
                Capacity = b.Capacity,
                Source = r.Source,
                Destination = r.Destination,
                RouteTag = r.RouteTag,
                SeatsAvailable = b.SeatsAvailable,
                Price = r.Price,
                DateAvailable = b.DateAvailable,
                DepartureTime = b.DepartureTime
            }).FirstOrDefault();
            if (currentBus.DateAvailable == travelDate)
            {
                FoundbusesList.Add(currentBus);
            }
        }
        return RedirectToAction(nameof(Booking));
    }

    [HttpGet]
    public IActionResult Booking()
    {
        var buses = FoundbusesList;
        return View(buses);
    }

    [HttpGet]
    public IActionResult Shopping()
    {
        var Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "Cart");
        ViewBag.Cart = Cart;
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> AddCart(int id)
    {

        var bus = await _dbContext.Buses.FirstOrDefaultAsync(b => b.BusId == id);
        var currentBus = _dbContext.Buses.Join(_dbContext.BusRoutes, b => b.BusId, r => r.BusId, (b, r) => new BusModel
        {
            BusId = b.BusId,
            BusNo = b.BusNo,
            Capacity = b.Capacity,
            Source = r.Source,
            Destination = r.Destination,
            RouteTag = r.RouteTag,
            SeatsAvailable = b.SeatsAvailable,
            Price = r.Price,
            DateAvailable = b.DateAvailable,
            DepartureTime = b.DepartureTime
        }).First();
        if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "Cart") == null)
        {
            List<CartItem> Cart = new List<CartItem>();
            Cart.Add(new CartItem { BusModel = currentBus, Quantity = 1 });
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", Cart);
        }
        else
        {
            List<CartItem> Cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "Cart");
            Cart.Add(new CartItem { BusModel = currentBus, Quantity = 1 });
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", Cart);
        }

        return RedirectToAction("Shopping");
    }

    public IActionResult Privacy()
    {
        return View();
    }
}

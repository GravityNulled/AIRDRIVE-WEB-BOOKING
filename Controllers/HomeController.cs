using Microsoft.AspNetCore.Mvc;
using CompanyMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using CompanyMvc.Data;

namespace CompanyMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dbContext;
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

    // [HttpPost]
    // public async Task<IActionResult> Index(RoutesViewModel routesViewModel)
    // {
    //     var route = routesViewModel.SelectedRouteTag;
    //     DateTime travelDate = routesViewModel.TravelDate;
    //     var routeBus = _dbContext.BusRoutes.FirstOrDefault(t => t.RouteTag == route);
    //     if (routeBus == null) return RedirectToAction(nameof(Index));
    //     var busFound = await _dbContext.Buses.FindAsync(Convert.ToInt32(routeBus.BusId));
    //     if (busFound == null) return RedirectToAction(nameof(Index));
    //     if (busFound.DateAvailable != travelDate) return RedirectToAction(nameof(Index));
    //     ViewBag.Buses = busFound;
    //     return RedirectToAction("Index", "Bus");
    // }

    public IActionResult Privacy()
    {
        return View();
    }
}

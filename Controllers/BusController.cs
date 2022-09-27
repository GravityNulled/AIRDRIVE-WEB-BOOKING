using CompanyMvc.Data;
using CompanyMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyMvc.Controllers
{
    public class BusController : Controller
    {
        private readonly ApplicationDbContext _dBcontext;
        public BusController(ApplicationDbContext dBcontext)
        {
            _dBcontext = dBcontext;
        }

        public async Task<ActionResult<BusModel>> Index()
        {
            var buses = await _dBcontext.Buses.Join(_dBcontext.BusRoutes, b => b.BusId, r => r.BusId, (b, r) => new BusModel
            {
                BusId = b.BusId,
                BusNo = b.BusNo,
                Capacity = b.Capacity,
                Source = r.Source,
                Destination = r.Destination,
                RouteTag = r.RouteTag,
                SeatsAvailable = b.SeatsAvailable,
                DateAvailable = b.DateAvailable,
                DepartureTime = b.DepartureTime
            }).ToListAsync();
            return View(buses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<Bus>> Create(Bus bus)
        {
            if (ModelState.IsValid)
            {
                _dBcontext.Buses.Add(bus);
                await _dBcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var bus = await _dBcontext.Buses.FindAsync(id);
            return View(bus);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Bus bus)
        {
            var bustoUpdate = await _dBcontext.Buses.FindAsync(bus.BusId);
            if (bustoUpdate == null)
            {
                return RedirectToAction(nameof(Index));
            }
            bustoUpdate.BusNo = bus.BusNo;
            bustoUpdate.BusRoute = bus.BusRoute;
            bustoUpdate.Capacity = bus.Capacity;
            bustoUpdate.SeatsAvailable = bus.SeatsAvailable;
            bustoUpdate.Type = bus.Type;
            await _dBcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
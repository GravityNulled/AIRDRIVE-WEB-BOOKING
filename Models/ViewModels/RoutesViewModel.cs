using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyMvc.Models.ViewModels
{
    public class RoutesViewModel
    {
        public string SelectedRouteTag { get; set; } = null!;
        public DateTime TravelDate { get; set; }
        public List<SelectListItem> SelectListSource { get; set; } = null!;
        public List<SelectListItem> SelectListDestination { get; set; } = null!;
    }
}
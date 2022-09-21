namespace CompanyMvc.Models
{
    public class BusRoute
    {
        public int BusRouteId { get; set; }
        public decimal Price { get; set; }
        public string RouteTag { get; set; } = null!;
        public string Source { get; set; } = null!;
        public string Destination { get; set; } = null!;
        //public int BusId { get; set; }
        //[JsonIgnore]

        public ICollection<Bus> Bus { get; set; } = null!;
    }
}
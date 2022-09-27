namespace CompanyMvc.Models
{
    public class BusModel
    {
        public int BusId { get; set; }
        public string BusNo { get; set; } = null!;
        public BusType Type { get; set; }
        public int Capacity { get; set; }
        public int SeatsAvailable { get; set; }
        public string? Source { get; set; }
        public string Destination { get; set; } = null!;
        public string? RouteTag { get; set; }
        public string? DepartureTime { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAvailable { get; set; }
    }
}
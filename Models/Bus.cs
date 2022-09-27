namespace CompanyMvc.Models
{
    public class Bus
    {
        public int BusId { get; set; }
        public string BusNo { get; set; } = null!;
        public BusType Type { get; set; }
        public int Capacity { get; set; }
        public int SeatsAvailable { get; set; }
        public string? DepartureTime { get; set; }
        public DateTime DateAvailable { get; set; }
        //[JsonIgnore]
        public BusRoute? BusRoute { get; set; } = null!;
    }
}
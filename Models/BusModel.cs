namespace CompanyMvc.Models
{
    public class BusModel
    {
        public int BusId { get; set; }
        public string BusNo { get; set; } = null!;
        public BusType Type { get; set; }
        public int Capacity { get; set; }
        public int SeatsAvailable { get; set; }
        public string Destination { get; set; } = null!;
    }
}
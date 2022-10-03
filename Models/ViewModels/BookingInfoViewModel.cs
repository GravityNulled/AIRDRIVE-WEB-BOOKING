namespace CompanyMvc.Models.ViewModels
{
    public class BookingInfoViewModel
    {
        public int BusId { get; set; }
        public string DeputureTime { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public string Source { get; set; } = null!;
        public decimal Price { get; set; }
        public string Name { get; set; } = null!;
        public string ApplicationUserId { get; set; } = null!;
    }
}
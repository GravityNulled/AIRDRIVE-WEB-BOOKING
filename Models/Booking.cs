using System.Text.Json.Serialization;

namespace CompanyMvc.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string DeputureTime { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public string Source { get; set; } = null!;
        public decimal Price { get; set; }
        public string Phone { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int BusId { get; set; }
        [JsonIgnore]

        public Bus? Bus { get; set; }
        public string ApplicationUserId { get; set; } = null!;
        [JsonIgnore]
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
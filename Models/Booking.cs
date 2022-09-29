using System.Text.Json.Serialization;

namespace CompanyMvc.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int BusId { get; set; }
        [JsonIgnore]

        public Bus? Bus { get; set; }
        public string DeputureTime { get; set; } = null!;
        public string ApplicationUserId { get; set; } = null!;
        [JsonIgnore]
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
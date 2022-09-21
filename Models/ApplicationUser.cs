using System.Text.Json.Serialization;

namespace CompanyMvc.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public int Age { get; set; }
        [JsonIgnore]

        public Booking Booking { get; set; } = null!;
    }
}
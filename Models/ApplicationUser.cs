using Microsoft.AspNetCore.Identity;

namespace CompanyMvc.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? NationalId { get; set; }
        public int Age { get; set; }
    }
}
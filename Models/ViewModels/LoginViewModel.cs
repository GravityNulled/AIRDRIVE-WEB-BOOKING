using System.ComponentModel.DataAnnotations;

namespace CompanyMvc.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        public bool Remember { get; set; }
    }
}
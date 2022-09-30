using System.ComponentModel.DataAnnotations;

namespace CompanyMvc.Models
{
    public class Payment
    {
        [Key]
        public int PaymemntId { get; set; }
        [Required]
        public long CardNumber { get; set; }
        [Required]
        public short CardCvv { get; set; }
        [Required]
        public string CardHolder { get; set; } = null!;
        public bool IsSuccess { get; set; } = true;
        [Required]
        public int ApplicationUserId { get; set; }
        //public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
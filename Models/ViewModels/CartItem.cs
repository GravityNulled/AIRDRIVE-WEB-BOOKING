namespace CompanyMvc.Models.ViewModels
{
    public class CartItem
    {
        public BusModel BusModel { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
using CompanyMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyMvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ApplicationUser> Users { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Bus> Buses { get; set; } = null!;
        public DbSet<BusRoute> BusRoutes { get; set; } = null!;
    }
}
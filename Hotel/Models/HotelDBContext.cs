using Microsoft.EntityFrameworkCore;
using Hotel.Models;

namespace Hotel.Models
{
    public class HotelDBContext: DbContext
    {
        public DbSet<HotelTable> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public HotelDBContext(DbContextOptions<HotelDBContext> options) : base(options)
        {

        }

        public DbSet<Hotel.Models.Reservation> Reservation { get; set; } = default!;
    }
}

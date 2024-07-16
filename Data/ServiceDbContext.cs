using Microsoft.EntityFrameworkCore;
using concert_booking_service_csharp.Models;

namespace concert_booking_service_csharp.Data
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<ConcertDate> ConcertDates { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<User> Users { get; set; }

    }
}

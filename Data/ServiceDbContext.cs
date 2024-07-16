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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Booking>()
        //        .HasMany(e => e.Seats)
        //        .WithOne(e => e.Booking)
        //        .HasForeignKey(e => e.BookingId)
        //        .IsRequired(false);

        //    modelBuilder.Entity<Concert>()
        //        .HasMany(e => e.ConcertDates)
        //        .WithOne(e => e.Concert)
        //        .HasForeignKey(e => e.ConcertId)
        //        .IsRequired();

        //}
    }
}

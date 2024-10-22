﻿using Microsoft.EntityFrameworkCore;
using concert_booking_service_csharp.Models;

namespace concert_booking_service_csharp.Data
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<ConcertDate> ConcertDates { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Navigation(s => s.User)
                .AutoInclude();

            modelBuilder.Entity<Booking>()
                .Navigation(s => s.Concert)
                .AutoInclude();

            modelBuilder.Entity<Booking>()
                .Navigation(s => s.Seats)
                .AutoInclude();

            modelBuilder.Entity<Concert>()
                .Navigation(s => s.ConcertDates)
                .AutoInclude();

            modelBuilder.Entity<Concert>()
                .Navigation(s => s.Performers)
                .AutoInclude();

        }

    }
}

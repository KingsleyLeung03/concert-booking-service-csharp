﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concert_booking_service_csharp.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BookingId { get; set; }

        // Foreign
        public long UserId { get; set; }

        // Foreign
        public long ConcertId { get; set; }

        public DateTime Date { get; set; }

        // Navigation
        public User User { get; set; }

        // Navigation
        public Concert Concert { get; set; }

        // Navigation
        public ICollection<Seat> Seats { get; set; }

    }
}
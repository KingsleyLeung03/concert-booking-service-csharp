﻿using concert_booking_service_csharp.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concert_booking_service_csharp.Models
{
    public class Performer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PerformerId { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public Genre Genre { get; set; }

        [MaxLength(1000)]
        public string Blurb { get; set; }

        // Navigation
        public virtual ICollection<Concert> Concerts { get; set; }

    }
}

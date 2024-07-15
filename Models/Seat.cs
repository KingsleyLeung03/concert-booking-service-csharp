using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concert_booking_service_csharp.Models
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Label { get; set; }

        public Boolean IsBooked { get; set; }

        public DateTime Date { get; set; }

        public double Cost { get; set; }

        // Navigation
        public Booking Booking { get; set; }
    }
}

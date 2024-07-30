using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concert_booking_service_csharp.Models
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SeatId { get; set; }

        public string Label { get; set; }

        public Boolean IsBooked { get; set; }

        public DateTime Date { get; set; }

        public double Cost { get; set; }

        // Foreign
        public long? BookingId { get; set; }

        // Navigation
        public virtual Booking? Booking { get; set; }
    }
}

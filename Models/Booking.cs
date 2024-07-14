using System.ComponentModel.DataAnnotations;

namespace concert_booking_service_csharp.Models
{
    public class Booking
    {
        [Key]
        public long Id { get; set; }

        public long UserId { get; set; }

        public long ConcertId { get; set; }

        public string Date { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concert_booking_service_csharp.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long UserId { get; set; }

        public long ConcertId { get; set; }

        public string Date { get; set; }

        // Navigation
        public ICollection<Seat> Seats { get; set; }

    }
}

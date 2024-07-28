using System.ComponentModel.DataAnnotations;

namespace concert_booking_service_csharp.Dtos
{
    public class BookingRequestDTO
    {
        [Required]
        public long ConcertId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public List<string> SeatLabels { get; set; }

    }
}

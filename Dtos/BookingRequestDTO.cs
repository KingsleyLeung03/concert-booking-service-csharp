using System.ComponentModel.DataAnnotations;

namespace concert_booking_service_csharp.Dtos
{
    public class BookingRequestDTO
    {
        [Required]
        public long concertId { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public List<String> seatLabels { get; set; }

    }
}

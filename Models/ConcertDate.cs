using System.ComponentModel.DataAnnotations;

namespace concert_booking_service_csharp.Models
{
    public class ConcertDate
    {
        [Key]
        public long Id { get; set; }

        public long ConcertId { get; set; }

        public DateTime Date { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace concert_booking_service_csharp.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        public string Label { get; set; }

        public DateTime Date { get; set; }

        public double Cost { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concert_booking_service_csharp.Models
{
    public class ConcertDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long ConcertId { get; set; }

        public DateTime Date { get; set; }

    }
}

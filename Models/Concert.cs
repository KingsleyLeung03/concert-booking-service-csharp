using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concert_booking_service_csharp.Models
{
    public class Concert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Title { get; set; }

        public string ImageName { get; set; }

        [MaxLength(1000)]
        public string Blurb { get; set; }

        // Navigation
        public ICollection<ConcertDate> ConcertDates { get; set; }

        // Navigation
        public ICollection<Performer> Performers { get; set; }

    }
}

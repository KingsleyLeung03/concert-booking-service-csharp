using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concert_booking_service_csharp.Models
{
    public class Concert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ConcertId { get; set; }

        public string Title { get; set; }

        public string ImageName { get; set; }

        [MaxLength(1000)]
        public string Blurb { get; set; }

        // Navigation
        public virtual ICollection<ConcertDate> ConcertDates { get; set; }

        // Navigation
        public virtual ICollection<Performer> Performers { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace concert_booking_service_csharp.Models
{
    public class Performer
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public string Genre { get; set; }

        public string Blurb { get; set; }

    }
}

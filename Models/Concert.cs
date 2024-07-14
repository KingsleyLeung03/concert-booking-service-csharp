using System.ComponentModel.DataAnnotations;

namespace concert_booking_service_csharp.Models
{
    public class Concert
    {
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }

        public string ImageName { get; set; }

        public string Blurb { get; set; }

    }
}

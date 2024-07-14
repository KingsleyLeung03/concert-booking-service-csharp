using System.ComponentModel.DataAnnotations;

namespace concert_booking_service_csharp.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public long Version { get; set; }

    }
}

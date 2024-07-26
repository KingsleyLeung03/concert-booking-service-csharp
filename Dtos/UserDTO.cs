using System.ComponentModel.DataAnnotations;

namespace concert_booking_service_csharp.Dtos
{
    public class UserDTO
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
    }
}

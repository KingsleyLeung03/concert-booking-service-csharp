using System.ComponentModel.DataAnnotations;

namespace concert_booking_service_csharp.Dtos
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

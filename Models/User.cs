using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace concert_booking_service_csharp.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        public long Version { get; set; }

    }
}

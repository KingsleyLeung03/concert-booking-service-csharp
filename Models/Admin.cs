using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace concert_booking_service_csharp.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AdminId { get; set; }

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

using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Model
{
    public class Login
    {
        [Key]
        public int? LoginId { get; set; }

        public string? UserId { get; set; }

        [Required]
       [MinLength(3)]
       [MaxLength(15)]
        public string? Password { get; set; }

    }
}

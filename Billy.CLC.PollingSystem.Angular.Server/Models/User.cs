using System.ComponentModel.DataAnnotations;

namespace Billy.CLC.PollingSystem.Angular.Server.Models
{
    public class User
    {

        [Required]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public byte[]? PasswordHash { get; set; }
        [Required]
        public byte[]? PasswordSalt { get; set; }
    }
}

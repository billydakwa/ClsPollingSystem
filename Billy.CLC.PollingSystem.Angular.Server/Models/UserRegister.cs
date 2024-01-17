using System.ComponentModel.DataAnnotations;

namespace Billy.CLC.PollingSystem.Angular.Server.Models
{
    public class UserRegister
    {
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}

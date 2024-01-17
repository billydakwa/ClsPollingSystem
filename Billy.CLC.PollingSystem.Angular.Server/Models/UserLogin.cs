using System.ComponentModel.DataAnnotations;

namespace Billy.CLC.PollingSystem.Angular.Server.Models
{
    public class UserLogin
    {
        [Required]
        public string? Username { get; set; }
        [Required] public string? Password { get; set; }
    }
}

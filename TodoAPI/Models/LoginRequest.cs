using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models
{
    // This class should be under view models, not models. Models is for database
    // entities
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required] 
        public string Password { get; set; }
    }
}

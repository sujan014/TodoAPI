using System.ComponentModel.DataAnnotations;

namespace TodoAPI.ViewModel
{
    public class RegisterRequest
    {
        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string Username { get; set; }
        
        [Required]
        [MinLength(8)]
        [MaxLength(32)]
        public string Password { get; set; }
        
        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

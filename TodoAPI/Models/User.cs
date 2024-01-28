using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }        
        public DateTime CreatedAt { get; set; }
        public ICollection<Todo> Todos { get; set; }
    }
}

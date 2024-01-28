using System.ComponentModel.DataAnnotations;

namespace TodoAPI.ViewModel
{
    public class EditTodoRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
    }
}

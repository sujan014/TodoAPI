namespace TodoAPI.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; } = null;
        public DateTime CreatedDate { get; set;}
        public DateTime UpdatedDate { get; set;}
        public User user { get; set; }
    }
}

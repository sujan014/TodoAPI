namespace TodoAPI.Models
{
    // This class should be under view models, not models. Models is for database
    // entities
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
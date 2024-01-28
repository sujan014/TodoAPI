using System.ComponentModel.DataAnnotations;

namespace TodoAPI.ViewModel
{
	public class CreateTodoRequest
	{
		public int Id { get; set; }

		[Required]
		[MinLength(2)]
		public string  Title { get; set; }

		[Required]
		[MinLength(5)]
        public string Description { get; set; }
        public DateTime? DueDate { get; set; } = null;
	}
}

using TodoAPI.Models;
using TodoAPI.ViewModel;

namespace TodoAPI.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<IEnumerable<Todo>> GetTodos(int userId);
        Task<Todo> CreateTodo(int userId, CreateTodoRequest request);        
        Task<Todo> EditTodo(int userId, EditTodoRequest request);
        Task<Todo> DeleteTodo(int userId, int id);
    }
}

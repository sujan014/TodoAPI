using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoAPI.Models;
using TodoAPI.ViewModel;

namespace TodoAPI.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoApiDBContext _context;

        public TodoService(TodoApiDBContext context)
        {
            _context = context;
        }

        public async Task<Todo> CreateTodo(int userId, CreateTodoRequest request)
        {            
            var todo = new Todo { 
                UserId = userId,
                Title = request.Title,
                Description = request.Description,
                IsCompleted = false,
                DueDate= request.DueDate,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }
        
        public async Task<Todo> DeleteTodo(int userId, int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync( todo => 
                todo.Id == id && todo.UserId == userId);

            if (todo == null)
            {
                throw new Exception($"Id {id} with UserId {userId} not found.");
            }
            _context.Remove( todo );
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo> EditTodo(int userId, EditTodoRequest request)
        {
            if (userId != request.UserId)
            {
                throw new Exception($"No Authorization error. \n" +
                    $"\tDetails: UserId {userId} not authorized to change database of UserId {request.UserId}."
                );
            }
            var todo = _context.Todos.FirstOrDefault( todo => todo.Id == request.Id);
            if (todo == null)
            {
                throw new Exception($"Todo with Id: {request.Id} not found in database.");
            }
            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.IsCompleted = request.IsCompleted;
            todo.DueDate = request.DueDate;
            todo.UpdatedDate = DateTime.Now;

            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _context.Todos.ToArrayAsync();
        }

        public async Task<IEnumerable<Todo>> GetTodos(int userId)
        {
            var todos = (await GetAllTodos())
                .Where(todo => todo.UserId == userId).ToList();
            return todos;
        }
    }
}

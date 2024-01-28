using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;
using TodoAPI.ViewModel;

namespace TodoAPI.Services
{
    public class UserService : IUserService
    {
        private readonly TodoApiDBContext _context;
        public UserService(TodoApiDBContext context)
        {
            _context = context;
        }

        public async Task<User> LoginUser(LoginRequest request)
        {
            if (request == null)
            {
                throw new Exception("Invalid user login");
            }

            var user = await _context.Users.FirstOrDefaultAsync(user => 
                user.Username == request.Username && user.Password == request.Password);

            return user;
        }

        public async Task<User> CreateUser(RegisterRequest request)
        {
            if (request == null)
            {
                throw new Exception("Invalid User register request");
            }
            var user = new User
            {
                Username = request.Username,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
    }
}

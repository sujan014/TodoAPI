using TodoAPI.Models;
using TodoAPI.ViewModel;

namespace TodoAPI.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(RegisterRequest request);

        Task<User> LoginUser(LoginRequest request);
        Task<IEnumerable<User>> GetUsers();
    }     
}

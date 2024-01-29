using TodoAPI.Models;
using TodoAPI.ViewModel;

namespace TodoAPI.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(RegisterRequest request);

        Task<string> LoginUser(LoginRequest request);
    }     
}

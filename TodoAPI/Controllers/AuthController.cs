using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoAPI.Models;
using TodoAPI.Services;
using TodoAPI.ViewModel;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public AuthController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        // This is very dangerous to expose as an API enpoint with no Authorization. Plus,
        // with no view model, you will return all users and passwords.
        // [HttpGet("getusers")]
        // public async Task<IActionResult> getUsers()
        // {
        //     var users = await _userService.GetUsers();
        //     return Ok(users);
        // }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            
            var user = await _userService.CreateUser(request);

            return Ok(user);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // The following changes make more logical sense. Before you only returned the user.
            // If you wanted to do that, the method should have been called something like
            // getUserByUsernameAndPassword. Naming is VERY important.


            string token;

            try {
                token = await _userService.LoginUser(user);
            } catch(Exection ex) {
                return BadRequest("Wrong username or password");
            }

            return Ok(token);
        }
    

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoAPI.Models;
using TodoAPI.Services;
using TodoAPI.ViewModel;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Authorize] // Use authorization token to access methods here
    [Route("api/todos")]
    public class ApiController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public ApiController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        //HTTP GET -> localhost:5555/api/todos/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(typeof(IEnumerable<Todo>))]
        public async Task<ActionResult> GetTodos()
        {
            var userId = GetUserId();
            var todos = await _todoService.GetTodos(userId);
            return Ok(todos);
        }

        //HTTP POST -> localhost:5555/api/todos/create
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(Todo))]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = GetUserId();
            var todo = await _todoService.CreateTodo(userId, request);
            return Ok(todo);
        }

        // HTTP POST -> localhost:5555/api/todos/edit
        [HttpPost("edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(Todo))]
        public async Task<IActionResult> EditTodo([FromBody] EditTodoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Are you sure this code is needed here?
            if (request == null)
            {
                return BadRequest("Edit request null error");
            }
            
            var userId = GetUserId();
            var todo = await _todoService.EditTodo(userId, request);
            return Ok(todo);
        }

        // HTTP POST -> localhost:5555/api/todos/delete
        [HttpPost("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Todo))]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var userId = GetUserId();
            var todo = await _todoService.DeleteTodo(userId, id);
            return Ok(todo);
        }

        protected int GetUserId()
        {
            var claim = this.User?.Claims?.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.PrimarySid));

            if (claim == null)
            {
                throw new Exception("User not authorized");
            }

            var userId = int.Parse(claim.Value);

            return userId;
        }
    }
}

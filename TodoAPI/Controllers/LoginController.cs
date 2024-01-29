using Microsoft.AspNetCore.Mvc;

// We also don't need this controller
namespace TodoAPI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }
    }
}

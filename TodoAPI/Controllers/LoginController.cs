using Microsoft.AspNetCore.Mvc;

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

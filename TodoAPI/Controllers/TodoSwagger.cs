using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers
{
    public class TodoSwaggerCOntroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

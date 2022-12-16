using Microsoft.AspNetCore.Mvc;

namespace miniprojekt_MVC.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet("/admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

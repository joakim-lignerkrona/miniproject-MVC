using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace miniprojekt_MVC.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet("/admin")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace miniprojekt_MVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        [HttpGet("/admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

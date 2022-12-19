using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using miniprojekt_MVC.Models;

namespace miniprojekt_MVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        GroupsService service;
        public AdminController(GroupsService service)
        {
            this.service = service;
        }

        [HttpGet("/admin")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/groups")]
        public IActionResult ListGroups()
        {
            var model = service.GetGroups();
            return View();
        }
    }
}

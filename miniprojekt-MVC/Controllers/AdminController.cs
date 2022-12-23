using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using miniprojekt_MVC.Models;
using miniprojekt_MVC.Views.Admin;

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
            var model = service.GetProjects();

            return View(model);
        }
        [HttpGet("/admin/Projects")]
        public IActionResult ProjectsList(string projectName)
        {
            var model = service.GetProjects();
            return View(model);
        }

        [HttpPost("/admin/Projects")]
        public IActionResult CreateProject(string Name)
        {
            service.CreateProject(Name);
            return RedirectToAction(nameof(ProjectsList));
        }


        [HttpGet("/admin/project/{projectId}")]
        public IActionResult Project(int projectId)
        {
            var people = service.GetPeople();
            var groups = service.GetProjectGroups(projectId);
            var model = new ProjectVM
            {
                form = people.Select(p => new ProjectVM.FormView
                {
                    People = p,
                    IsSelected = (Random.Shared.Next(0, 2) == 0 ? true : false)
                }).ToArray(),
                groups = null

            };
            return View(model);
        }


    }
}

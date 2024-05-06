using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TretaPractical.Models;
using TretaPractical.Repository;

namespace TretaPractical.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProject _project;

        public HomeController(ILogger<HomeController> logger, IProject project)
        {
            _logger = logger;
            _project = project;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Project project)
        {
            _project.AddProject(project);
            return View();
        }

        [HttpGet("GetAllProject")]
        public async Task<JsonResult> GetAllProject()
        {
            var projects =  _project.GetAllProject();
            return Json(projects);
        }
        [HttpGet("GetAllEmployee")]
        public async Task<JsonResult> GetAllEmployee()
        {
            var employees = _project.GetEmployee();
            return Json(employees);
        }

        [HttpPost("AssignTask")]
        public async Task<IActionResult> ProjectAssign(ProjectAssign projectAssign)
        {
            _project.ProjectAssign(projectAssign.ProjectIdRef, projectAssign.EmployeeIdRef);
            return null;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
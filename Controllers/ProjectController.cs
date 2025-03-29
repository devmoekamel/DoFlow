using FreelanceManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FreelanceManager.Repositry;

namespace FreelanceManager.Controllers
{
    public class ProjectController : Controller
    {
        IProjectRepo projectRepo;
        public ProjectController(IProjectRepo projectRepo)
        {
            this.projectRepo = projectRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

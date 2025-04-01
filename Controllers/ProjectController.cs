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
        // project
        public IActionResult Index()
        {
            var projects = projectRepo.GetAll();
            return View(projects);
        }


        public IActionResult Details(int id)
        {
            var project = projectRepo.GetById(id);
        
            return View(project);
        }

    }
}

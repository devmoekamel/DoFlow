using FreelanceManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FreelanceManager.Repositry;
using FreelanceManager.ViewModels.Project;
using FreelanceManager.Enums;

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
            var projects = projectRepo.GetAll()
                .Select(p=> new AllProjectsVM {
                Name=p.Name,
                Priority=p.Priority,
                Budget = p.Budget,
                Company = p.Company,
                AllMissionsCount = p.Missions.Count(),
                CompletedMissionsCount = p.Missions.Count(m=>m.Status==status.Completed),
                Description = p.Description,
                EndDate = p.EndDate,
                HourlyRate = p.HourlyRate,
                Id =p.Id,
                ProjectStatus=p.Status,
                StartDate = p.StartDate
                });
            return View(projects);
        }


        public IActionResult Details(int id)
        {
          //  var project = projectRepo.GetById(id);
        
            return View();
        }

    }
}

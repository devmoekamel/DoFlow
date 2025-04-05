using FreelanceManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FreelanceManager.Repositry;
using FreelanceManager.ViewModels.Projectvm;
using FreelanceManager.Models;
using FreelanceManager.Enums;
using Microsoft.AspNetCore.Authorization;

namespace FreelanceManager.Controllers
{

    public class ProjectController : Controller
    {
        private readonly IProjectRepo projectRepo;
        private readonly IMissionRepo missionRepo;
        private readonly IClientRepo clientRepo;
        public ProjectController(IProjectRepo projectRepo, IMissionRepo missionRepo, IClientRepo clientRepo)
        {
            this.projectRepo = projectRepo;
            this.missionRepo = missionRepo;
            this.clientRepo = clientRepo;
        }
        // project
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var projects = projectRepo.GetAll()
                .Select(p => new AllProjectsVM {
                    Name = p.Name,
                    Priority = p.Priority,
                    Budget = p.Budget,
                    Company = p.Company,
                    AllMissionsCount = p.Missions.Count(),
                    CompletedMissionsCount = p.Missions.Count(m => m.Status == status.Completed),
                    Description = p.Description,
                    EndDate = p.EndDate,
                    HourlyRate = p.HourlyRate,
                    Id = p.Id,
                    ProjectStatus = p.Status,
                    StartDate = p.StartDate
                });
           

            return View(projects);
        }


        public IActionResult Details(int id)
        {
            var project = projectRepo.GetById(id);
            ProjectDetialsVM projectDetialsVM = new ProjectDetialsVM();
            projectDetialsVM.Id = id;
            projectDetialsVM.Name = project.Name;
            projectDetialsVM.Budget = project.Budget;
            projectDetialsVM.HourlyRate = project.HourlyRate;
            projectDetialsVM.Description = project.Description;
            projectDetialsVM.Status = project.Status;
            projectDetialsVM.StartDate = project.StartDate;
            projectDetialsVM.EndDate = project.EndDate;
            projectDetialsVM.Company = project.Company;
            projectDetialsVM.Priority = project.Priority;
            projectDetialsVM.AllMissionsCount = project.Missions.Count();
            projectDetialsVM.Categoty = project.Categoty;
            projectDetialsVM.ClientName = project.Client.Name;
            projectDetialsVM.CompletedMissionsCount = project.Missions.Count(m => m.Status == status.Completed);
            projectDetialsVM.Missions = missionRepo.GetAll();
            return View(projectDetialsVM);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddProjectVM newproject = new AddProjectVM();
            ViewBag.Clients = clientRepo.GetAll();
            return PartialView("AddProjectPartialView", newproject);
        }

        [HttpPost]

        public IActionResult SaveAdd(AddProjectVM project)
          {
            if (!ModelState.IsValid)
            {
                ViewBag.Clients = clientRepo.GetAll();
                return PartialView("AddProjectPartialView", project);
            }

            Console.WriteLine(project.Name);
            Console.WriteLine(project.Budget);
            Console.WriteLine(project.ClientId);
            Console.WriteLine(project.Company);
            Console.WriteLine(project.Description);
            Console.WriteLine(project.StartDate);
            Console.WriteLine(project.EndDate);

            Project newProject = new()
            {
                Name = project.Name,
                Budget = project.Budget,
                ClientId = project.ClientId,
                Company = project.Company,
                Description = project.Description,
                StartDate= project.StartDate,
                EndDate= project.EndDate,
                HourlyRate  = project.HourlyRate,
                Priority = project.Priority,
              
                
            };

            projectRepo.Add(newProject);

            projectRepo.Save();

            return RedirectToAction("Index");
        }






    }
}

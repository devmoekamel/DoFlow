using FreelanceManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FreelanceManager.Repositry;
using FreelanceManager.ViewModels.Project;
using FreelanceManager.Enums;
using Microsoft.AspNetCore.Authorization;

namespace FreelanceManager.Controllers
{
    public class ProjectController : Controller
    {
		private readonly IProjectRepo projectRepo;
		private readonly IMissionRepo missionRepo;

		public ProjectController(IProjectRepo projectRepo, IMissionRepo missionRepo)
        {
            this.projectRepo = projectRepo;
			this.missionRepo = missionRepo;
		}
        // project
        [HttpGet]
        [Authorize]
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
            // add client name
            projectDetialsVM.CompletedMissionsCount = project.Missions.Count(m=>m.Status == status.Completed);
            projectDetialsVM.Missions = missionRepo.GetAll();
			return View();
        }



    }
}

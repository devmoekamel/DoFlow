using FreelanceManager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceManager.Controllers
{
    public class OverviewController : Controller
    {
        private readonly IClientRepo clientRepo;
        private readonly IMissionRepo missionRepo;
        private readonly IProjectRepo projectRepo;
        private readonly ITimeTrackingRepo timeTrackingRepo;

        public OverviewController(IClientRepo clientRepo,IMissionRepo missionRepo , IProjectRepo projectRepo,ITimeTrackingRepo timeTrackingRepo)
        {
            this.clientRepo = clientRepo;
            this.missionRepo = missionRepo;
            this.projectRepo = projectRepo;
            this.timeTrackingRepo = timeTrackingRepo;
        }
        public IActionResult Index()
        {
            OverviewVM overview = new()
            { ClientsNum = clientRepo.GetAll().Count(),
              RecentTasks= missionRepo.GetAll().TakeLast(5),
              RecentProjects =projectRepo.GetAll().TakeLast(5),
              TasksNum= missionRepo.GetAll().Count(),
              ProjectsNum= projectRepo.GetAll().Count(),
            };
            return View(overview);
        }
    }
}

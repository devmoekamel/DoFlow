using System.Security.Claims;
using FreelanceManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FreelanceManager.Controllers
{

    public class OverviewController : Controller
    {
        private readonly IClientRepo clientRepo;
        private readonly IMissionRepo missionRepo;
        private readonly IProjectRepo projectRepo;
        private readonly ITimeTrackingRepo timeTrackingRepo;

        public OverviewController(IClientRepo clientRepo, IMissionRepo missionRepo, IProjectRepo projectRepo, ITimeTrackingRepo timeTrackingRepo)
        {
            this.clientRepo = clientRepo;
            this.missionRepo = missionRepo;
            this.projectRepo = projectRepo;
            this.timeTrackingRepo = timeTrackingRepo;
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Register", "Freelancer");
            }
            string Userid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value; // this return id of user
            Console.WriteLine(Userid);

            var projects = projectRepo.GetAll().Where(p => p.FreelancerId == Userid);
            OverviewVM overview = new()
            {
                ClientsNum = projects.Select(p => p.Client).Count(),
                RecentTasks = projects.SelectMany(p=>p.Missions),
                RecentProjects = projects.TakeLast(5),
                TasksNum = projects.SelectMany(p => p.Missions).Count(),
                ProjectsNum = projects.Count(),
                PendingInvoices=projects.SelectMany(p => p.Invoices).Count()
            };
            return View(overview);
        }
    }
}

	
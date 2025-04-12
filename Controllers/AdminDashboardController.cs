using FreelanceManager.Interfaces;
using FreelanceManager.Repositry;
using FreelanceManager.ViewModels.DashboradVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace FreelanceManager.Controllers
{
    //[Authorize(Roles = "Admin")]

    public class AdminDashboardController : Controller
    {
        private readonly IClientRepo clientRepo;
        private readonly IMissionRepo missionRepo;
        private readonly IFreelancerRepo freelancerRepo;
        private readonly IProjectRepo projectRepo;
        private readonly ITimeTrackingRepo timeTrackingRepo;
        UserManager<Freelancer> userManager;

        public AdminDashboardController(IFreelancerRepo freelancerRepo,IClientRepo clientRepo, IMissionRepo missionRepo, IProjectRepo projectRepo, ITimeTrackingRepo timeTrackingRepo, UserManager<Freelancer> userManager)
        {
            this.freelancerRepo = freelancerRepo;
            this.clientRepo = clientRepo;
            this.missionRepo = missionRepo;
            this.projectRepo = projectRepo;
            this.timeTrackingRepo = timeTrackingRepo;
            this.userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var freelancers = await userManager.GetUsersInRoleAsync("Freelancer");

            var dashboardList = new List<DashboardVM>();

            foreach (var user in freelancers)
            {
                var userId = user.Id;

                var projects = projectRepo.GetAll()
                    .Where(p => p.FreelancerId == userId && p.IsDeleted == false)
                    .ToList();

                var missions = missionRepo.GetAll()
                    .Where(m => projects.Select(p => p.Id).Contains(m.ProjectId))
                    .ToList();

                var missionIds = missions.Select(m => m.Id);

                var totalDuration = new TimeSpan(
                     timeTrackingRepo.GetAll()
                    .Where(t => missionIds.Contains(t.MissionId))
                    .Sum(d => d.Duration.Ticks)
                    );

                dashboardList.Add(new DashboardVM
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    ProjectCount = projects.Count,
                    MissionCount = missions.Count,
                    TodayHours = totalDuration
                });
            }

            return View("Index", dashboardList);
        }

        [HttpPost]
        public IActionResult Delete(string UserId)
        {
            var client = freelancerRepo.GetByIdString(UserId);
            if (client == null)
            {
                return NotFound();
            }
            
                client.IsDeleted = true;
                freelancerRepo.Save();
            return Json(new { success = true });


        }
    }
}


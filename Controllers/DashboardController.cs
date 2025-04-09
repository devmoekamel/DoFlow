using FreelanceManager.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace FreelanceManager.Controllers
{
    [Authorize(Roles = "Admin")]

    public class DashboardController : Controller
    {
        private readonly IClientRepo clientRepo;
        private readonly IMissionRepo missionRepo;
        private readonly IProjectRepo projectRepo;
        private readonly ITimeTrackingRepo timeTrackingRepo;
        UserManager<Freelancer> userManager;

        public DashboardController(IClientRepo clientRepo, IMissionRepo missionRepo, IProjectRepo projectRepo, ITimeTrackingRepo timeTrackingRepo, UserManager<Freelancer> userManager)
        {
            this.clientRepo = clientRepo;
            this.missionRepo = missionRepo;
            this.projectRepo = projectRepo;
            this.timeTrackingRepo = timeTrackingRepo;
            this.userManager= userManager;
        }
        #region today_project

        //public IActionResult Index() 
        //{
        //    var today = DateTime.Today;
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var projects = projectRepo.GetAll().Where(p => p.FreelancerId == userId).ToList();
        //    var projectCount = projects.Count;

        //    var projectId = projects.Select(p => p.Id);
        //    var missions = missionRepo.GetAll().Where(m => projectId.Contains(m.ProjectId)).ToList();
        //    var missionId = missions.Select(m => m.Id);
        //    var missionCount = missions.Count;
        //        var durations = timeTrackingRepo.GetAll()
        //            .Where(t => missionId.Contains(t.MissionId) && t.Date.Date == today)
        //            .Select(t => t.Duration)
        //            .ToList();
        //    var totalDuration = new TimeSpan(durations.Sum(d => d.Ticks));
        //    //var timeTrackingSum = totalDuration.ToString(@"hh\:mm\:ss");

        //    DashboardVM dashboardData = new DashboardVM
        //    {
        //        Projects = projectCount,
        //        Missions = missionCount,
        //        TodayHours = totalDuration
        //    };
            
           
        //    return View("index", dashboardData);

        //}
        #endregion

        
            public async Task<IActionResult> Index()
            {
                var freelancers = await userManager.GetUsersInRoleAsync("Freelancer");

                var dashboardList = new List<DashboardVM>();

                foreach (var user in freelancers)
                {
                    var userId = user.Id;

                    // المشاريع الخاصة بالفريلانسر
                    var projects = projectRepo.GetAll()
                        .Where(p => p.FreelancerId == userId)
                        .ToList();

                    // المهام المرتبطة بالمشاريع دي
                    var missions = missionRepo.GetAll()
                        .Where(m => projects.Select(p => p.Id).Contains(m.ProjectId))
                        .ToList();

                    var missionIds = missions.Select(m => m.Id);

                    // التراكات لكل المهام بدون فلترة على التاريخ
                    var durations = timeTrackingRepo.GetAll()
                        .Where(t => missionIds.Contains(t.MissionId))
                        .Select(t => t.Duration)
                        .ToList();

                    var totalDuration = new TimeSpan(durations.Sum(d => d.Ticks));

                    dashboardList.Add(new DashboardVM
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        ProjectCount = projects.Count,
                        MissionCount = missions.Count,
                        TodayHours = totalDuration // ممكن تغير اسم الخاصية في الـ ViewModel لو مش حابب يكون اسمه Today
                    });
                }

                return View("Index", dashboardList);
            }

        }

    }


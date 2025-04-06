using FreelanceManager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceManager.Controllers
{
    public class TimeTrackingController : Controller
    {
        private readonly ITimeTrackingRepo timerRepo;
        private readonly IMissionRepo missionRepo;

        public TimeTrackingController(ITimeTrackingRepo timerRepo, IMissionRepo missionRepo) 
        {
            this.timerRepo = timerRepo;
            this.missionRepo = missionRepo;
        }
        public IActionResult Index()
        {
            var missions = missionRepo.GetAll().ToList();
            var model = new TimeTrackingVM
            {
                AvailableMissions = missions
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveTimeTracking(TimeTrackingVM TimeVM)
        {
            if (!ModelState.IsValid)
            {
                TimeVM.AvailableMissions = missionRepo.GetAll().ToList();
                return View("Index", TimeVM);
            }

            var timeTracking = new TimeTracking
            {
                Id = TimeVM.Id,
                Date = TimeVM.Date,
                Duration = TimeVM.Duration,
                EstimateTime = TimeVM.EstimateTime,
                MissionId = TimeVM.MissionId,
            };

            timerRepo.Add(timeTracking);
            timerRepo.Save();

            return RedirectToAction("Index");
        }


    }
}

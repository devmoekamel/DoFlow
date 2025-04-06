using FreelanceManager.Interfaces;
using FreelanceManager.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var timers = timerRepo.GetAll().ToList();

            var model = timers.Select(timer => new TimeTrackingVM
            {
                Id = timer.Id,
                Date = timer.Date,
                Duration = timer.Duration,
                EstimateTime = timer.EstimateTime,
                MissionId = timer.MissionId,
                AvailableMissions = missionRepo.GetAll().ToList()
            }).ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult Tracking()
        {

            var model = new TimeTrackingVM
            {
                AvailableMissions = missionRepo.GetAll().ToList()
            };
            return View("Tracking",model);
            
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
            TimeVM.AvailableMissions = missionRepo.GetAll().ToList();
            timerRepo.Add(timeTracking);
            timerRepo.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            timerRepo.RemoveById(id);
            return RedirectToAction("Index");
        }

    }
}

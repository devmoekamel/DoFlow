using FreelanceManager.Interfaces;
using FreelanceManager.Models;
using FreelanceManager.ViewModels.TimeTracking;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations.Schema;
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
                MissionId = timer.MissionId
            }).ToList();

            ViewBag.AvailableMissions = missionRepo.GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveTimeTracking([FromBody] SaveTimeTracking saveTime)
        {
            if (ModelState.IsValid)
            {
                var timeTracking = new TimeTracking
                {
                    Date = DateTime.Now,
                    Duration = saveTime.Duration,
                    MissionId = saveTime.MissionId,
                };
                ViewBag.AvailableMissions = missionRepo.GetAll().ToList();
                timerRepo.Add(timeTracking);
                timerRepo.Save();
                return Json(new { sucess=true ,Message = ""});
            }
            return Json(new { sucess = false, Message = "Something not coorect happen" });
        }

        [HttpPost]
        public IActionResult Delete([FromBody]int id)
        {
            timerRepo.RemoveById(id);
            return Json(new { sucess = true });
        }

    }
}

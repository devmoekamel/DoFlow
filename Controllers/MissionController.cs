using FreelanceManager.Enums;
using FreelanceManager.Interfaces;
using FreelanceManager.Models;
using FreelanceManager.Repositry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FreelanceManager.Controllers
{
    public class MissionController : Controller
    {
        private readonly IMissionRepo missionRepo;
        private readonly IProjectRepo projectRepo;

        public MissionController(IMissionRepo missionRepo,IProjectRepo projectRepo) 
        {
            this.missionRepo = missionRepo;
            this.projectRepo =projectRepo;
        }
        #region GetAll

        [HttpGet]
        public IActionResult Index(string? search, status? status, priority? priority)
        {
            var mission = missionRepo.GetAllFilter(search, status, priority).ToList();
            //map to MissionViewModel
            List<MissionViewModel> MissView = mission.Select(m => new MissionViewModel
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Status = m.Status,
                Priority = m.Priority,
                Deadline = m.Deadline,
                ProjectId = m.ProjectId
            }).ToList();

            return View("All", MissView);
        }
        #endregion

        #region Details

        [HttpGet]
        public IActionResult Details(int id)
        {
            Mission mission = missionRepo.GetById(id);
            MissionViewModel viewMission = new MissionViewModel
            {
                Id = mission.Id,
                Title = mission.Title,
                Description = mission.Description,
                Status = mission.Status,
                Priority = mission.Priority,
                Deadline = mission.Deadline,
                ProjectId = mission.ProjectId
            };
            var projectName = projectRepo.GetById(mission.ProjectId).Name;
            ViewBag.ProjectName = projectName;
            return View("DetailsPartial",viewMission);
        }

        #endregion

        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            var model = new MissionViewModel();
            ViewBag.ProjectList = projectRepo.GetAll();
            return PartialView("AddPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAdd(MissionViewModel mission)
        {
            if (ModelState.IsValid)
            {
                Mission newmission = new Mission();
                newmission.Title = mission.Title;
                newmission.Description = mission.Description;
                newmission.Status = mission.Status;
                newmission.Priority = mission.Priority;
                newmission.Deadline = mission.Deadline;
                newmission.ProjectId = mission.ProjectId;

                missionRepo.Add(newmission);
                missionRepo.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectList = projectRepo.GetAll();
            return PartialView("AddPartial", mission);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var mission = missionRepo.GetById(id);
            MissionViewModel Editmission = new MissionViewModel {
                Id = mission.Id,
                Title = mission.Title,
                Description = mission.Description,
                Status = mission.Status,
                Priority = mission.Priority,
                Deadline = mission.Deadline,
                ProjectId = mission.ProjectId
            };
            ViewBag.ProjectList = projectRepo.GetAll();
            return View("EditPartial",Editmission);
        }
        #endregion

        #region SaveEdit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(MissionViewModel mission)
        {
            if (ModelState.IsValid)
            {
                Mission Editmission = missionRepo.GetById(mission.Id);

                Editmission.Title = mission.Title;
                Editmission.Description = mission.Description;
                Editmission.Status = mission.Status;
                Editmission.Priority = mission.Priority;
                Editmission.Deadline = mission.Deadline;
                Editmission.ProjectId = mission.ProjectId;

                missionRepo.Save();
                return RedirectToAction("GetAll");
            }
            return View("EditPartial",mission);
        }
        #endregion


        #region Delete


        [HttpPost]
        public IActionResult Delete(MissionViewModel obj)
        {
            Mission mission = missionRepo.GetById(obj.Id);

            if (mission != null)
            {
                missionRepo.RemoveById(obj.Id);
                missionRepo.Save();
                return RedirectToAction("GetAll");

            }
            else
            {
                return NotFound("Task not Exist");
            }

        }

        #endregion
    }
}

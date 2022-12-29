using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Models;
using RunGroupWebApp.RepoInterfaces;
using RunGroupWebApp.ViewModels;

namespace RunGroupWebApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public RaceController(IRaceRepository raceRepository, IHttpContextAccessor contextAccessor)
        {
            _raceRepository = raceRepository;
            this._contextAccessor = contextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            var races = await _raceRepository.GetAll();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Race race = await _raceRepository.GetByIdAsync(id);
            return View(race);
        }

        public async Task<IActionResult> Create()
        {
            var userId = _contextAccessor.HttpContext.User.GetId();
            CreateRaceViewModel race = new CreateRaceViewModel() { AppUserId = userId };
            return View(race);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRaceViewModel race)
        {
            if (!ModelState.IsValid)
            {
                return View(race);
            }

            Race r = new Race()
            {
                Title = race.Title,
                Description = race.Description,
                Address = race.Address,
                Image = race.Image,
                RaceCategory = race.RaceCategory,
                AppUserId = race.AppUserId
            };

            _raceRepository.Add(r);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Race race = await _raceRepository.GetByIdAsync(id);
            if (race == null)
            {
                return View("Error");
            }
            return View(race);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Race race)
        {
            if (!ModelState.IsValid)
            {
                return View(race);
            }
            _raceRepository.Update(race);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var race = await _raceRepository.GetByIdAsync(id);
            if (race != null)
            {
                _raceRepository.Delete(race);
            }
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Models;
using RunGroupWebApp.RepoInterfaces;

namespace RunGroupWebApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;

        public RaceController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Race race)
        {
            if (!ModelState.IsValid)
            {
                return View(race);
            }
            _raceRepository.Add(race);
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

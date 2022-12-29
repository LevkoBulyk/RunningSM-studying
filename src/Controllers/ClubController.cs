using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Models;
using RunGroupWebApp.RepoInterfaces;

namespace RunGroupWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            this._clubRepository = clubRepository;
        }

        public async Task<IActionResult> Index()
        {
            var clubs = await _clubRepository.GetAll();
            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> Create(Club club)
        {
            if (!ModelState.IsValid)
            {
                return View(club);
            }
            _clubRepository.Add(club);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            if (club == null)
            {
                return View("Error");
            }
            return View(club);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(int id, Club club)
        {
            if (!ModelState.IsValid)
            {
                return View(club);
            }
            _clubRepository.Update(club);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var club = await _clubRepository.GetByIdAsync(id);
            if (club != null)
            {
                _clubRepository.Delete(club);
            }

            return RedirectToAction("Index");
        }

    }
}

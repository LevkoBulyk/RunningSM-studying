using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Models;
using RunGroupWebApp.RepoInterfaces;
using RunGroupWebApp.ViewModels;

namespace RunGroupWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public ClubController(IClubRepository clubRepository, IHttpContextAccessor contextAccessor)
        {
            this._clubRepository = clubRepository;
            _contextAccessor = contextAccessor;
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
            var userId = _contextAccessor.HttpContext.User.GetId();
            var club = new CreateClubViewModel()
            {
                AppUserId = userId
            };
            return View(club);
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> Create(CreateClubViewModel club)
        {
            if (!ModelState.IsValid)
            {
                return View(club);
            }

            Club c = new Club()
            {
                Title = club.Title,
                Description = club.Description,
                Image = club.Image,
                AppUserId = club.AppUserId,
                Address = club.Address,
                ClubCategory = club.ClubCategory
            };

            _clubRepository.Add(c);
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

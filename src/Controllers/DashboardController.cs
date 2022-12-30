using Microsoft.AspNetCore.Mvc;
using RunGroupWebApp.Data;
using RunGroupWebApp.Models;
using RunGroupWebApp.RepoInterfaces;
using RunGroupWebApp.Repository;
using RunGroupWebApp.ViewModels;

namespace RunGroupWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public DashboardController(IDashboardRepository dashboardRepository, IHttpContextAccessor contextAccessor)
        {
            _dashboardRepository = dashboardRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var userRaces = await _dashboardRepository.GetAllUserRaces();
            var userClubs = await _dashboardRepository.GetAllUserClubs();
            var data = new DashboardViewModel()
            {
                Races = userRaces,
                Clubs = userClubs
            };
            return View(data);
        }

        public async Task<IActionResult> EditMyProfile()
        {
            var id = _contextAccessor.HttpContext.User.GetId();
            var user = await _dashboardRepository.GetUserById(id);

            if (user == null)
            {
                return View("Error");
            }

            UserViewModel data = new UserViewModel()
            {
                Id = id,
                UserName = user.UserName,
                Pace = user.Pace,
                Mileage = user.Mileage
            };
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> EditMyProfile(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "User data is not valid";
                return View(user);
            }

            var data = await _dashboardRepository.GetUserById(user.Id);

            data.Id = user.Id;
            data.UserName = user.UserName;
            data.Pace = user.Pace;
            data.Mileage = user.Mileage;

            _dashboardRepository.UpdateUser(data);
            return RedirectToAction("Index");
        }
    }
}

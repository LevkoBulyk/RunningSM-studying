using RunGroupWebApp.Data;
using RunGroupWebApp.Models;
using RunGroupWebApp.RepoInterfaces;

namespace RunGroupWebApp.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AppDBContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public DashboardRepository(AppDBContext context, IHttpContextAccessor httpContextAccessor) 
        {
            _context = context;
            _contextAccessor = httpContextAccessor;
        }


        public async Task<List<Club>> GetAllUserClubs()
        {
            var userId = _contextAccessor.HttpContext?.User.GetId();
            var userClubs = _context.Clubs.Where(r => r.AppUser.Id == userId);
            return userClubs.ToList();
        }

        public async Task<List<Race>> GetAllUserRaces()
        {
            var userId = _contextAccessor.HttpContext?.User.GetId();
            var userRaces = _context.Races.Where(r => r.AppUser.Id == userId);
            return userRaces.ToList();
        }
    }
}

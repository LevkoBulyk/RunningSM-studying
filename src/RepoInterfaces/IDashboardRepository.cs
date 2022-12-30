using RunGroupWebApp.Models;

namespace RunGroupWebApp.RepoInterfaces
{
    public interface IDashboardRepository
    {
        Task<List<Race>> GetAllUserRaces();
        Task<List<Club>> GetAllUserClubs();
        Task<AppUser> GetUserById(string id);
        bool UpdateUser(AppUser user);
    }
}

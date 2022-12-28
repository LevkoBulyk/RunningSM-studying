using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RunGroupWebApp.Data;
using RunGroupWebApp.Models;
using RunGroupWebApp.RepoInterfaces;

namespace RunGroupWebApp.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private AppDBContext _context;

        public RaceRepository(AppDBContext context)
        {
            _context = context;
        }

        public bool Add(Race race)
        {
            _context.Races.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            _context.Races.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<Race> GetByIdAsync(int id)
        {
            return await _context.Races.Include(a => a.Address).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Race>> GetClubByCity(string city)
        {
            return await _context.Races.Include(a => a.Address).Where(c => c.Address.City == city).ToListAsync();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(Race club)
        {
            _context.Races.Update(club);
            return Save();
        }
    }
}

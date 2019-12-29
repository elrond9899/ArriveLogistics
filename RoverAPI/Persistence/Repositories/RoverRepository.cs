using RoverAPI.Persistence.Models;
using System.Threading.Tasks;

namespace RoverAPI.Persistence.Repositories
{
    public class RoverRepository : IRoverRepository
    {
        private readonly AppDbContext _context;

        public RoverRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IRover> GetAsync(string id)
        {
            return await _context.MarsRovers.FindAsync(id);
        }
        public async Task<IRover> UpdateAsync(IRover rover)
        {
            _context.MarsRovers.Update((MarsRover)rover);
            await _context.SaveChangesAsync();
            return await GetAsync(rover.RoverId);
        }
    }
}

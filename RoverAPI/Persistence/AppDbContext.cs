using Microsoft.EntityFrameworkCore;
using RoverAPI.Persistence.Models;

namespace RoverAPI.Persistence
{
    public class AppDbContext: DbContext
    {
        public DbSet<MarsRover> MarsRovers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        { }
    }
}

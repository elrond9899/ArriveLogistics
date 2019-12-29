using RoverAPI.Persistence.Models;
using System.Threading.Tasks;

namespace RoverAPI.Persistence.Repositories
{
    public interface IRoverRepository
    {
        Task<IRover> GetAsync(string id);
        Task<IRover> UpdateAsync(IRover rover);
    }
}

using System.Threading.Tasks;

namespace RoverAPI.Persistence.Services
{
    public interface IRoverMovementService
    {
        Task<RoverCurrentPositionResponse> GetAsync(AlphaNumericIdString id);
        Task<RoverCurrentPositionResponse> UpdateAsync(AlphaNumericIdString id, MovementInstruction instruction);
    }
}

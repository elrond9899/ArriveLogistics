using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoverAPI.Persistence;
using RoverAPI.Persistence.Services;

namespace RoverAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoversController : ControllerBase
    {
        private readonly ILogger<RoversController> _logger;
        private readonly IRoverMovementService _roverService;

        public RoversController(ILogger<RoversController> logger, IRoverMovementService roverService)
        {
            _logger = logger;
            _roverService = roverService;

        }

        [HttpGet("{id:alphanumericidstring}/currentPosition")]
        public async Task<ActionResult<RoverCurrentPositionResponse>> GetCurrentPositionAsync(string id)
        {
            var positionResponse = await _roverService.GetAsync(new AlphaNumericIdString(id));
            if(!positionResponse.Success)
            {
                return StatusCode(positionResponse.ErrorCode.Value, positionResponse.Message);
            }
            
            return positionResponse;
        }

        [HttpPost("{id:alphanumericidstring}/currentPosition")]
        public async Task<ActionResult<RoverCurrentPositionResponse>> UpdateCurrentPositionAsync(string id, [FromBody]MovementInstruction movement)
        {
            var positionResponse = await _roverService.UpdateAsync(new AlphaNumericIdString(id), movement);
            if (!positionResponse.Success)
            {
                return StatusCode(positionResponse.ErrorCode.Value, positionResponse.Message);
            }

            return positionResponse;
        }
    }
}

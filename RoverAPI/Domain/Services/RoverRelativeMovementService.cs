using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RoverAPI.Persistence.Enums;
using RoverAPI.Persistence.Models;
using RoverAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoverAPI.Persistence.Services
{
    public partial class RoverRelativeMovementService : IRoverMovementService
    {
        private readonly ILogger<RoverRelativeMovementService> _logger;
        private readonly IRoverRepository _roverRepository;

        private readonly CircularList<CompassDirectionXYMovement> _compassTurnKey =
            new CircularList<CompassDirectionXYMovement>(new List<CompassDirectionXYMovement>()
            {
               new CompassDirectionXYMovement(CompassDirection.N, 0, 1),
               new CompassDirectionXYMovement(CompassDirection.E, 1, 0),
               new CompassDirectionXYMovement(CompassDirection.S, 0, -1),
               new CompassDirectionXYMovement(CompassDirection.W, -1, 0)
            });
    
        private class CompassDirectionXYMovement
        {
            public CompassDirection Direction { get; }
            public int XAxisMovement { get; }
            public int YAxisMovement { get; }

            public CompassDirectionXYMovement(CompassDirection direction, int xAxisMovement, int yAxisMovement)
            {
                Direction = direction;
                XAxisMovement = xAxisMovement;
                YAxisMovement = yAxisMovement;
            }
        }

        public RoverRelativeMovementService(ILogger<RoverRelativeMovementService> logger, IRoverRepository roverRepository)
        {
            _logger = logger;
            _roverRepository = roverRepository;
        }

        public async Task<RoverCurrentPositionResponse> GetAsync(AlphaNumericIdString id)
        {
            // Use concatenation to invoke the implicit conversion for AlphanumericIdString
            string convertedId = id;
            IRover rover;
            try
            {
                rover = await _roverRepository.GetAsync(id);
            }
            catch(Exception exception)
            {
                var errorMessage = $"Error occurred saving position for rover with id {convertedId}.";
                _logger.LogError(exception, errorMessage);
                return new RoverCurrentPositionResponse(errorMessage, string.Empty, false, StatusCodes.Status500InternalServerError);
            }

            if(rover == null)
            {
                return new RoverCurrentPositionResponse($"Rover with id {convertedId} not found.", null, false, StatusCodes.Status404NotFound);
            }

            return new RoverCurrentPositionResponse($"Retrieved position for rover with id {convertedId}", FormatRelativePosition(rover.XPosition, rover.YPosition), true, null);
        }

        public async Task<RoverCurrentPositionResponse> UpdateAsync(AlphaNumericIdString id, MovementInstruction movement)
        {
            var rover = await _roverRepository.GetAsync(id);
            _compassTurnKey.CurrentIndex = _compassTurnKey.FindIndex(i => i.Direction == rover.FacingDirection);

            foreach (var individualInstruction in movement.Instruction.ToCharArray())
            {
                if (individualInstruction == 'M')
                {
                    rover.XPosition += _compassTurnKey.CurrentItem.XAxisMovement;
                    rover.YPosition += _compassTurnKey.CurrentItem.YAxisMovement;
                }

                if (individualInstruction == 'L')
                {
                    _compassTurnKey.PreviousItem();
                }

                if(individualInstruction == 'R')
                {
                    _compassTurnKey.NextItem();
                }                
            }

            rover.FacingDirection = _compassTurnKey.CurrentItem.Direction;

            // Use concatenation to invoke the implicit conversion for AlphanumericIdString
            string convertedId = id;
            try
            {
                rover = await _roverRepository.UpdateAsync(rover);
            }
            catch (Exception exception)
            {
                var errorMessage = $"Error occurred saving position for rover with {convertedId}";
                _logger.LogError(exception, errorMessage);
                return new RoverCurrentPositionResponse(errorMessage, string.Empty, false, StatusCodes.Status500InternalServerError);
            }

            if (rover == null)
            {
                return new RoverCurrentPositionResponse($"Rover with id {convertedId} not found.", null, false, StatusCodes.Status404NotFound);
            }

            return new RoverCurrentPositionResponse($"Updated position for rover with id {convertedId}.", FormatRelativePosition(rover.XPosition, rover.YPosition), true, null);
        }

        private string FormatRelativePosition(int x, int y)
        {
            return $"({x},{y})";
        }
    }
}

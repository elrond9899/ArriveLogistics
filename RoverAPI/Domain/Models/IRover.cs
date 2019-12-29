using RoverAPI.Persistence.Enums;
namespace RoverAPI.Persistence.Models
{
    public interface IRover
    {
        string RoverId { get; set; }
        int XPosition { get; set; }
        int YPosition { get; set; }

        CompassDirection FacingDirection { get; set; }
    }
}

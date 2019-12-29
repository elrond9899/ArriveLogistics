using System.ComponentModel;

namespace RoverAPI.Persistence.Enums
{
    public enum MoveInstruction
    {
        [Description("Rotate 90 degrees to the right")]
        R,
        [Description("Rotate 90 degrees to the left")]
        L,
        [Description("Move forward one unit")]
        M
    }
}

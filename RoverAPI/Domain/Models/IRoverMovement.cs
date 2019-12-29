namespace RoverAPI.Persistence.Models
{
    public interface IRoverMovement
    {
        MovementInstruction Instruction { get; set; }
    }
}
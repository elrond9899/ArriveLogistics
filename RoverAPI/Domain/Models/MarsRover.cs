using RoverAPI.Persistence.Enums;
using System.ComponentModel.DataAnnotations;

namespace RoverAPI.Persistence.Models
{
    public class MarsRover: IRover
    {
        [Key]
        public string RoverId { get; set; }
        
        [Required]
        public int XPosition { get; set; }
        
        [Required]
        public int YPosition { get; set; }

        [Required]
        public CompassDirection FacingDirection  { get; set; }
    }
}

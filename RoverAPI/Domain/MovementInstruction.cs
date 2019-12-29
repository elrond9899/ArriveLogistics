using RoverAPI.Persistence.Enums;
using System;
using System.Text.RegularExpressions;

namespace RoverAPI.Persistence
{
    public class MovementInstruction
    {
        private const int minLength = 1;
        private const int maxLength = 100;

        private static readonly string movementInstructionRegEx = $"^[RLM]{{{minLength},{maxLength}}}$";
        private static readonly Regex regex;

        private string _instruction;
        public string Instruction 
        {
            get { return _instruction; }
            set 
            {
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException(
                        $"String must have length <= 100 and can only contain the following characters: {string.Join(string.Empty, Enum.GetNames(typeof(MoveInstruction)))}");
                }

                _instruction = value;
            }
        }

        static MovementInstruction()
        {
            regex = new Regex(movementInstructionRegEx);
        }
    }
}

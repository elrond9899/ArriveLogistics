namespace RoverAPI.Persistence.Services
{
    public class RoverCurrentPositionResponse: BaseResponse
    {
        public string CurrentPosition { get; private set; }

        public RoverCurrentPositionResponse(string message, string currentPosition, bool success, int? errorCode): base(message, success, errorCode)
        {
            CurrentPosition = currentPosition;
        }
    }
}

using System.Text.Json.Serialization;

namespace RoverAPI.Persistence.Services
{
    public abstract class BaseResponse
    {
        public string Message { get; protected set; }
        
        [JsonIgnore]
        public bool Success { get; protected set; }
        
        [JsonIgnore]
        public int? ErrorCode { get; protected set; }

        public BaseResponse(string message, bool success, int? errorCode)
        {
            Message = message;
            Success = success;
            ErrorCode = errorCode;
        }
    }
}

using Microsoft.AspNetCore.Routing.Constraints;

namespace RoverAPI.Persistence
{
    public class AlphanumericIdRouteConstraint : RegexRouteConstraint
    {
        public AlphanumericIdRouteConstraint() : base($"^[a-zA-Z0-9]*$")
        {}
    }
}

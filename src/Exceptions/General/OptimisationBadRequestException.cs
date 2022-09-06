using ConcreteMixerTruckRoutingServer.Exceptions.Base;

namespace ConcreteMixerTruckRoutingServer.Exceptions.General
{
    public class OptimisationBadRequestException : ExceptionBase
    {
        public const string BASE_MESSAGE = "Route calculation failed.";

        public OptimisationBadRequestException() : base(BASE_MESSAGE) { }
    }
}

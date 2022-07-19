using ConcreteMixerTruckRoutingServer.Exceptions.Base;

namespace ConcreteMixerTruckRoutingServer.Exceptions.General
{
    public class GenericBadRequestException : ExceptionBase
    {
        public GenericBadRequestException(string errorMessage) : base(errorMessage) { }
    }
}

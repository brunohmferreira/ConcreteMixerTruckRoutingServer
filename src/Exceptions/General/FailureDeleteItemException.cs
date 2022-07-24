using ConcreteMixerTruckRoutingServer.Exceptions.Base;

namespace ConcreteMixerTruckRoutingServer.Exceptions.General
{
    public class FailureDeleteItemException : ExceptionBase
    {
        public FailureDeleteItemException(string entity) : base(string.Format(BASE_MESSAGE, entity)) { }

        public const string BASE_MESSAGE = "Failed to delete {0} item.";
    }
}

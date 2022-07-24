using ConcreteMixerTruckRoutingServer.Exceptions.Base;

namespace ConcreteMixerTruckRoutingServer.Exceptions.General
{
    public class FailureInsertItemException : ExceptionBase
    {
        public FailureInsertItemException(string entity) : base(string.Format(BASE_MESSAGE, entity)) { }

        public const string BASE_MESSAGE = "Failed to include {0} item.";
    }
}

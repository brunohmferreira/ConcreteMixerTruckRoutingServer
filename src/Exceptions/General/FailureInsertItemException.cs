using ConcreteMixerTruckRoutingServer.Exceptions.Base;

namespace ConcreteMixerTruckRoutingServer.Exceptions.General
{
    public class FailureInsertItemException : ExceptionBase
    {
        public FailureInsertItemException(string entity) : base(string.Format(BASE_MESSAGE, entity)) { }

        public const string BASE_MESSAGE = "Falha ao incluir {0}.";
    }
}

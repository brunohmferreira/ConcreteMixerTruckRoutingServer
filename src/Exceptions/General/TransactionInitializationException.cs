using ConcreteMixerTruckRoutingServer.Exceptions.Base;

namespace ConcreteMixerTruckRoutingServer.Exceptions.General
{
    public class TransactionInitializationException : ExceptionBase
    {
        public TransactionInitializationException() : base($"Transaction must be initialized.") { }
    }
}

using ConcreteMixerTruckRoutingServer.Exceptions.Base;

namespace ConcreteMixerTruckRoutingServer.Exceptions.General
{
    public class TransactionWithoutUnitOfWorks : ExceptionBase
    {
        public TransactionWithoutUnitOfWorks() : base("UnitOfWorks List can't be empty.") { }
    }
}
